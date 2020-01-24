using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierreSweets.Models
{
  public class PierreSweetsContextFactory : IDesignTimeDbContextFactory<PierreSweetsContext>
  {

    PierreSweetsContext IDesignTimeDbContextFactory<PierreSweetsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<PierreSweetsContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new PierreSweetsContext(builder.Options);
    }
  }
}