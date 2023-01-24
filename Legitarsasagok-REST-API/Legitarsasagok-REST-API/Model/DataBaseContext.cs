using Legitarsasagok_REST_API.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
            //modelBuilder.Entity<RepuloJaratok>().HasMany(x => x.Menetrend).WithOne(x=>x.RepuloJaratok);

            modelBuilder.Entity<Menetrend>().HasOne(x => x.RepuloJaratok).WithMany(x => x.Menetrend);

            #region Varosok
            int a = 1;
            modelBuilder.Entity<Varosok>().HasData(
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "Budapest",
                        Nepesseg = 1760000
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "London",
                        Nepesseg = 8980000
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "Parizs",
                        Nepesseg = 2160000
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "Berlin",
                        Nepesseg = 3720000
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "Bécs",
                        Nepesseg = 1900000
                    }
                );
            #endregion
            #region RepuloJaratok
            int b = 1;
            modelBuilder.Entity<RepuloJaratok>().HasData(
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",                                                                                                                                         
                        Honnan = "Budapest",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Parizs",
                        Tavolsag = 1250,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Berlin",
                        Tavolsag = 685,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Bécs",
                        Tavolsag = 215,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Párizs",
                        Tavolsag = 340,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Berlin",
                        Tavolsag = 930,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Bécs",
                        Tavolsag = 1230,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Berlin",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Bécs",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Párizs",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Bécs",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Párizs",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    },
                    new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Berlin",
                        Tavolsag = 1450,
                        UtazasiIdo = 145,
                        UtazasiDij = 6
                    }
                );
            #endregion
            #region Menetrend
            int c = 1;
            modelBuilder.Entity<Menetrend>().HasData(
                    new Menetrend
                    {
                        ID = (uint)c++,
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