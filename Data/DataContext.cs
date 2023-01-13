using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Properties.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Properties.Data
{
    // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    //dotnet tool install --global dotnet-ef
    //dotnet add package Microsoft.EntityFrameworkCore.Design

    //da bi se koristio DbContext treba da se uvede EntityFrameworkCore
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}