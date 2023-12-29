using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using PremierLeaguePredictions.Models;
using System.Net.Http;

namespace PremierLeaguePredictions.Pages
{
    public class IndividualModel : PageModel
    {
        public string Person { get; set; }
        private IMemoryCache _cacheProvider;
        public List<IndividualPrediction> predictions_table { get; set; } = new List<IndividualPrediction>();

        public IndividualModel(IMemoryCache cache)
        {
            _cacheProvider = cache;
        }
        public void OnGet(string person)
        {
            Person = person;
            if ((!_cacheProvider.TryGetValue("Predictions_diff", out List<TableData> preds_table_diff)) || (!_cacheProvider.TryGetValue("Predictions", out List<Predictions> preds)))
            {
                RedirectToPage("Index");
            }
            else
            {
                switch (person.ToLower())
                {
                    case "ss":
                        foreach(var row in preds)
                        {
                            predictions_table.Add(new IndividualPrediction
                            {
                                Team = row.Team,
                                Actual = preds_table_diff.Where(i => i.Team == row.Team).First().Actual,
                                pred = row.ss_pred,
                                diff = preds_table_diff.Where(i => i.Team == row.Team).First().ss_diff
                            });
                            predictions_table = predictions_table.OrderBy(o => o.pred).ToList();
                        }
                        break;
                    case "lm":
                        foreach (var row in preds)
                        {
                            predictions_table.Add(new IndividualPrediction
                            {
                                Team = row.Team,
                                Actual = preds_table_diff.Where(i => i.Team == row.Team).First().Actual,
                                pred = row.lm_pred,
                                diff = preds_table_diff.Where(i => i.Team == row.Team).First().lm_diff
                            });
                            predictions_table = predictions_table.OrderBy(o => o.pred).ToList();
                        }
                        break;
                    case "jl":
                        foreach (var row in preds)
                        {
                            predictions_table.Add(new IndividualPrediction
                            {
                                Team = row.Team,
                                Actual = preds_table_diff.Where(i => i.Team == row.Team).First().Actual,
                                pred = row.jl_pred,
                                diff = preds_table_diff.Where(i => i.Team == row.Team).First().jl_diff
                            });
                            predictions_table = predictions_table.OrderBy(o => o.pred).ToList();
                        }
                        break;
                    case "dd":
                        foreach (var row in preds)
                        {
                            predictions_table.Add(new IndividualPrediction
                            {
                                Team = row.Team,
                                Actual = preds_table_diff.Where(i => i.Team == row.Team).First().Actual,
                                pred = row.dd_pred,
                                diff = preds_table_diff.Where(i => i.Team == row.Team).First().dd_diff
                            });
                            predictions_table = predictions_table.OrderBy(o => o.pred).ToList();
                        }
                        break;
                    default:
                        RedirectToPage("Index");
                        break;
                }
            }
        }
    }
}
