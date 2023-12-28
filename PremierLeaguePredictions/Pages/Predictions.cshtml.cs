using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using PremierLeaguePredictions.Data;
using PremierLeaguePredictions.Models;
using static PremierLeaguePredictions.Models.PremierLeague;

namespace PremierLeaguePredictions.Pages
{
    public class PredictionsModel : PageModel
    {
        private readonly PredictionsDBContext _dbContext;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private IMemoryCache _cacheProvider;
        Root tabledata { get; set; }
        public List<Row> PLTable { get; set; }

        public List<TableData> predictions_table { get; set; } =new List<TableData>();
        public List<Predictions> predictions { get; set; }
        public PredictionsModel(PredictionsDBContext predictionsDBContext, IConfiguration configuration, IMemoryCache cache)
        {
            _dbContext = predictionsDBContext;
            _httpClient = new HttpClient();
            _configuration = configuration;
            _cacheProvider = cache;

        }
        public void OnGet()
        {
            predictions = _dbContext.Predictions.ToList();

            if (!_cacheProvider.TryGetValue("TableData", out string contentstream))
            {
                using HttpResponseMessage httpClientResponse = _httpClient.GetAsync(_configuration["APIUrl"]).Result;

                contentstream = httpClientResponse.Content.ReadAsStringAsync().Result;
                _cacheProvider.Set("TableData", contentstream);
            }

            tabledata = JsonConvert.DeserializeObject<Root>(contentstream.ToString());

            Item subjson = tabledata.items.Where(e => e.competitionDetails.title == "Premier League").First();

            PLTable = subjson.standings.tables[0].rows;

            foreach(var item in predictions)
            {
                foreach(Row row in PLTable)
                {
                    if(row.clubName.ToLower() == item.Team.ToLower())
                    {
                        predictions_table.Add(new TableData
                        {
                            Team = item.Team,
                            Actual = row.position,
                            ss_diff = Math.Abs(item.ss_pred - row.position),
                            lm_diff = Math.Abs(item.lm_pred - row.position),
                            jl_diff = Math.Abs(item.jl_pred - row.position),
                            dd_diff = Math.Abs(item.dd_pred - row.position)
                        });
                    }
                }
            }

            predictions_table = predictions_table.OrderBy(o=>o.Actual).ToList();
        }
    }
}
