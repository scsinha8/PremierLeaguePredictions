using Microsoft.EntityFrameworkCore;

namespace PremierLeaguePredictions.Models
{
    [Keyless]
    public class Predictions
    {
        public string Team { get; set; }
        public int ss_pred { get; set; }
        public int lm_pred { get; set; }
        public int jl_pred { get; set; }
        public int dd_pred { get; set; }

    }

    public class TableData
    {
        public string Team { get; set; }
        public int ss_diff { get; set; }
        public int lm_diff { get; set; }
        public int jl_diff { get; set; }
        public int dd_diff { get; set; }
        public int Actual { get; set; }
    }
}
