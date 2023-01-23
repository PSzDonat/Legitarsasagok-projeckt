using Legitarsasagok_REST_API.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legitarsasagok_REST_API.Controllers
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Varosok> Varosok { get; set; }
        public DbSet<RepuloJaratok> RepuloJaratok { get; set; }
        public DbSet<Menetrend> Menetrend { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "127.0.0.1";
            builder.InitialCatalog = "Legitarsasagok";
            builder.Authentication = SqlAuthenticationMethod.SqlPassword;
            builder.UserID = "sa";
            builder.Password = "P@55w0rd";
            optionsBuilder.UseSqlServer(builder.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Varosok>().HasMany(x=>x.RepuloJaratok).WithOne(x=>x.Varosok);

            modelBuilder.Entity<RepuloJaratok>().HasOne(x => x.Varosok).WithMany(x=>x.RepuloJaratok);
            modelBuilder.Entity<RepuloJaratok>().HasMany(x => x.Menetrend).WithOne(x=>x.RepuloJaratok);

            modelBuilder.Entity<Menetrend>().HasOne(x => x.RepuloJaratok).WithMany(x => x.Menetrend);

            #region Varosok
            modelBuilder.Entity<Varosok>().HasData(
                    new Varosok
                    {
                        ID = 1,
                        VarosNeve = "Budapest",
                        Nepesseg = 1800000
                    },
                    new Varosok
                    {
                        ID = 2,
                        VarosNeve = "Budapest",
                        Nepesseg = 1800000
                    }
                );
            #endregion
            #region RepuloJaratok
            modelBuilder.Entity<RepuloJaratok>().HasData(
                    new RepuloJaratok
                    {
                        ID = 1,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = 2,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    }
                );
            #endregion
            #region Menetrend
            modelBuilder.Entity<Menetrend>().HasData(
                    new Menetrend
                    {
                        ID = 1,
                        RepuloJarat_ID = 1,
                        FelszallasIdopontja = new DateTime(2023, 01, 23, 19,2,40),
                        LelszallasIdopontja = new DateTime(2023, 01, 23, 19, 2, 40),
                        Ara = 32000
                    },
                    new Menetrend
                    {
                        ID = 2,
                        RepuloJarat_ID = 2,
                        FelszallasIdopontja = new DateTime(2023, 01, 23, 19, 2, 40),
                        LelszallasIdopontja = new DateTime(2023, 01, 23, 19, 2, 40),
                        Ara = 32000
                    }
                );
            #endregion
        }
    }
}