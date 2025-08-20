using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Estoque.Data; // <-- Correção aqui: usar o namespace correto

namespace Estoque.Data
{
    public class EstoqueContextFactory : IDesignTimeDbContextFactory<EstoqueContext>
    {
        public EstoqueContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EstoqueContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            );

            return new EstoqueContext(optionsBuilder.Options);
        }
    }
}
