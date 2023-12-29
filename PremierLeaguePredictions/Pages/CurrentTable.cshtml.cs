using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using static PremierLeaguePredictions.Models.PremierLeague;

namespace PremierLeaguePredictions.Pages
{
    public class CurrentTableModel : PageModel
    {
        public bool IsAuthorized => HttpContext.User.HasClaim("IsAuthorized", bool.TrueString);

        private readonly ILogger<PrivacyModel> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private IMemoryCache _cacheProvider;

        Root tabledata { get; set; }
        public List<Row> PLTable { get; set; }

        public CurrentTableModel(ILogger<PrivacyModel> logger, IConfiguration configuration, IMemoryCache cache)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _configuration = configuration;
            _cacheProvider = cache;
        }

        public void OnGet()
        {
            if (!_cacheProvider.TryGetValue("TableData", out string contentstream))
            {
                using HttpResponseMessage httpClientResponse = _httpClient.GetAsync(_configuration["APIUrl"]).Result;

                contentstream = httpClientResponse.Content.ReadAsStringAsync().Result;
                _cacheProvider.Set("TableData", contentstream);
            }

            tabledata = JsonConvert.DeserializeObject<Root>(contentstream.ToString());

            Item subjson = tabledata.items.Where(e => e.competitionDetails.title == "Premier League").First();

            PLTable = subjson.standings.tables[0].rows;
        }
    }
}
