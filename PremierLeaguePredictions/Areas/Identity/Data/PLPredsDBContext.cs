using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictions.Areas.Identity.Data;
using PremierLeaguePredictions.Models;

namespace PremierLeaguePredictions.Data;

public class PLPredsDBContext : IdentityDbContext<PremierLeaguePredictionsUser>
{
    public PLPredsDBContext(DbContextOptions<PLPredsDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}

public class PredictionsDBContext : DbContext
{
    public PredictionsDBContext(DbContextOptions<PredictionsDBContext> options)
        : base(options)
    {
    }

    public DbSet<Predictions> Predictions { get; set; }
}
