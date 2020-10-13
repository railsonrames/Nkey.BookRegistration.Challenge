using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Nkey.BookRegistration.Challenge.Data.Context.EntitiesMaping;
using Nkey.BookRegistration.Challenge.Data.Entities;
using System;
using System.IO;

namespace Nkey.BookRegistration.Challenge.Data.Context
{
    public class BookRegistrationContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookMapping());
        }

        #region private methods
        private string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder();
            var configurationFilePath = Path.Combine(Directory.GetCurrentDirectory().Replace("Data", "Api"), "appsettings.json");
            configuration.AddJsonFile(configurationFilePath, false);
            var configurationJson = configuration.Build();
            var connectionString = configurationJson.GetSection("AzureDataBaseConnection").Value;
            if (connectionString == null) throw new Exception("String de conexão com o banco de dados é nula, verificar configuração.");
            return connectionString.Replace("{your_password}", "Brasil12*");
        }
        #endregion
    }
}
