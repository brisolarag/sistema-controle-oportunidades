using api_opportunities.Models.Opportunities;
using Microsoft.EntityFrameworkCore;

namespace api_opportunities.Data;
public class AppDbContext : DbContext
{
    public DbSet<Opportunity> AllOpportunities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=sql;User ID=sa;Password=SenhaBancoTeste123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True");
        
        base.OnConfiguring(optionsBuilder);
    }
}

