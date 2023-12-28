using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PremierLeaguePredictions.Data;
using PremierLeaguePredictions.Models;

namespace PremierLeaguePredictions.Pages
{
    public class PredictionsModel : PageModel
    {
        private readonly PredictionsDBContext _dbContext;
        public PredictionsModel(PredictionsDBContext predictionsDBContext)
        {
            _dbContext = predictionsDBContext;
        }
        public void OnGet()
        {
            List<Predictions> predictions = _dbContext.Predictions.ToList();
        }
    }
}
