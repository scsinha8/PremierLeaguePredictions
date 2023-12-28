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
}
