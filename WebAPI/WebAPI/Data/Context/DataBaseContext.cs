using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entity;

namespace WebAPI.Data.Context
{
  public class DataBaseContext : DbContext
  {
    public DataBaseContext(DbContextOptions<DataBaseContext> options)
      : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(StringConectionConfig());
      }
    }

    public DbSet<ClienteEntity> Clientes { get; set; }


    private string StringConectionConfig()
    {
      return "Server=DESKTOP-24V97RI;Database=DB_CLI;User Id=sa;Password=mbelo;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES";
    }

  }
}
