using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DCSolution.Data.EF
{
    public class DbContextFactory : IDesignTimeDbContextFactory<DCSolutionDBContext>
    {
        public DCSolutionDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DCSolutionDB");

            var optionsBuilder = new DbContextOptionsBuilder<DCSolutionDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new DCSolutionDBContext(optionsBuilder.Options);
        }
    }
}
