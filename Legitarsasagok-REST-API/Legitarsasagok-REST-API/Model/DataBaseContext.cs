using Legitarsasagok_REST_API.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Legitarsasagok_REST_API.Model
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Varosok> Varosok { get; set; }
        public DbSet<RepuloJaratok> RepuloJaratok { get; set; }
        public DbSet<Menetrend> Menetrend { get; set; }
        public DbSet<Foglalasok> Foglalasok { get; set; }

        public Random rnd = new Random();
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

            modelBuilder.Entity<Menetrend>().HasMany(x => x.Foglalasok).WithOne(x => x.Menetrend);

            #region Varosok
            int a = 1;
            List<Varosok> varos_data = new List<Varosok>
            {
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
                        VarosNeve = "Párizs",
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
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "New York",
                        Nepesseg = 8460000
                    },
                    new Varosok
                    {
                        ID = (uint)a++,
                        VarosNeve = "Tokió",
                        Nepesseg = 13960000
                    }
            };
            modelBuilder.Entity<Varosok>().HasData(varos_data);
            #endregion
            #region RepuloJaratok
            int b = 1;
            List<RepuloJaratok> rj_data = new List<RepuloJaratok> {
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 120,
                        UtazasiDij = 7
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Párizs",
                        Tavolsag = 1250,
                        UtazasiIdo = 100,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Berlin",
                        Tavolsag = 685,
                        UtazasiIdo = 60,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Bécs",
                        Tavolsag = 215,
                        UtazasiIdo = 25,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "New York",
                        Tavolsag = 7000,
                        UtazasiIdo = 525,
                        UtazasiDij = 10
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Budapest",
                        Hova = "Tokió",
                        Tavolsag = 9050,
                        UtazasiIdo = 680,
                        UtazasiDij = 11
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "New York",
                        Hova = "Budapest",
                        Tavolsag = 7000,
                        UtazasiIdo = 525,
                        UtazasiDij = 10
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Tokió",
                        Hova = "Budapest",
                        Tavolsag = 9050,
                        UtazasiIdo = 680,
                        UtazasiDij = 11
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 120,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Párizs",
                        Tavolsag = 340,
                        UtazasiIdo = 30,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Berlin",
                        Tavolsag = 930,
                        UtazasiIdo = 75,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "London",
                        Hova = "Bécs",
                        Tavolsag = 1230,
                        UtazasiIdo = 100,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Budapest",
                        Tavolsag = 1250,
                        UtazasiIdo = 100,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "London",
                        Tavolsag = 340,
                        UtazasiIdo = 30,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Berlin",
                        Tavolsag = 875,
                        UtazasiIdo = 70,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Párizs",
                        Hova = "Bécs",
                        Tavolsag = 1030,
                        UtazasiIdo = 90,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Budapest",
                        Tavolsag = 685,
                        UtazasiIdo = 62,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Párizs",
                        Tavolsag = 875,
                        UtazasiIdo = 73,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "London",
                        Tavolsag = 930,
                        UtazasiIdo = 75,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Berlin",
                        Hova = "Bécs",
                        Tavolsag = 520,
                        UtazasiIdo = 46,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Budapest",
                        Tavolsag = 215,
                        UtazasiIdo = 25,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "London",
                        Tavolsag = 1230,
                        UtazasiIdo = 100,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Párizs",
                        Tavolsag = 1030,
                        UtazasiIdo = 80,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Wizz Air",
                        Honnan = "Bécs",
                        Hova = "Berlin",
                        Tavolsag = 520,
                        UtazasiIdo = 43,
                        UtazasiDij = 6
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Budapest",
                        Hova = "London",
                        Tavolsag = 1450,
                        UtazasiIdo = 120,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Budapest",
                        Hova = "Párizs",
                        Tavolsag = 1250,
                        UtazasiIdo = 100,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Budapest",
                        Hova = "Berlin",
                        Tavolsag = 685,
                        UtazasiIdo = 60,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Budapest",
                        Hova = "Bécs",
                        Tavolsag = 215,
                        UtazasiIdo = 25,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "New York",
                        Tavolsag = 5570,
                        UtazasiIdo = 420,
                        UtazasiDij = 10
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "Tokió",
                        Tavolsag = 9560,
                        UtazasiIdo = 720,
                        UtazasiDij = 11
                    },

                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "New York",
                        Hova = "London",
                        Tavolsag = 5570,
                        UtazasiIdo = 420,
                        UtazasiDij = 10
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Tokió",
                        Hova = "London",
                        Tavolsag = 9560,
                        UtazasiIdo = 720,
                        UtazasiDij = 11
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "Budapest",
                        Tavolsag = 1450,
                        UtazasiIdo = 120,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "Párizs",
                        Tavolsag = 340,
                        UtazasiIdo = 30,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "Berlin",
                        Tavolsag = 930,
                        UtazasiIdo = 75,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "London",
                        Hova = "Bécs",
                        Tavolsag = 1230,
                        UtazasiIdo = 100,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Párizs",
                        Hova = "Budapest",
                        Tavolsag = 1250,
                        UtazasiIdo = 100,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Párizs",
                        Hova = "London",
                        Tavolsag = 340,
                        UtazasiIdo = 30,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Párizs",
                        Hova = "Berlin",
                        Tavolsag = 875,
                        UtazasiIdo = 70,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Párizs",
                        Hova = "Bécs",
                        Tavolsag = 1030,
                        UtazasiIdo = 90,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Berlin",
                        Hova = "Budapest",
                        Tavolsag = 685,
                        UtazasiIdo = 62,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Berlin",
                        Hova = "Párizs",
                        Tavolsag = 875,
                        UtazasiIdo = 73,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Berlin",
                        Hova = "London",
                        Tavolsag = 930,
                        UtazasiIdo = 75,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Berlin",
                        Hova = "Bécs",
                        Tavolsag = 520,
                        UtazasiIdo = 46,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Bécs",
                        Hova = "Budapest",
                        Tavolsag = 215,
                        UtazasiIdo = 25,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Bécs",
                        Hova = "London",
                        Tavolsag = 1230,
                        UtazasiIdo = 100,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Bécs",
                        Hova = "Párizs",
                        Tavolsag = 1030,
                        UtazasiIdo = 80,
                        UtazasiDij = 9
                    },
                new RepuloJaratok
                    {
                        ID = (uint)b++,
                        Legitarsasag = "Air Atlanta Europe",
                        Honnan = "Bécs",
                        Hova = "Berlin",
                        Tavolsag = 520,
                        UtazasiIdo = 43,
                        UtazasiDij = 9
                    }
            };
            modelBuilder.Entity<RepuloJaratok>().HasData(rj_data);
            #endregion
            #region Menetrend
            int c = 1;
            List<Menetrend> ment_data = new List<Menetrend> {};
            int LTS_ora = 0;
            int LTS_perc = 0;
            bool Tulcsordult_ora = false;
            bool Tulcsordult_perc = false;
            double IFA = 0;
            int index = 0;
            bool megVan = true;
            int nepesseg = 0;
            foreach (var item in rj_data)
            {
                TimeSpan FTS = new TimeSpan( rnd.Next(0, 24),int.Parse(rnd.Next(0, 6).ToString()+"0"),0);
                int ora = (int)Calculate.CalcOra(item.UtazasiIdo);
                int perc = (int)Calculate.CalcPerc(item.UtazasiIdo, ora);
                LTS_ora = 0;
                LTS_perc = 0;
                Tulcsordult_ora = false;
                Tulcsordult_perc = false;
                if (FTS.Minutes + perc >= 60)
                {
                    LTS_perc = (FTS.Minutes + perc) - 60;
                    Tulcsordult_perc = true;
                }
                if (Tulcsordult_perc == true)
                {
                    ora++;
                }
                if (FTS.Hours + ora >= 24)
                {
                    LTS_ora = (FTS.Hours + ora) - 24;
                    Tulcsordult_ora = true;
                }
                TimeSpan LTS = new TimeSpan(LTS_ora,LTS_perc,0);
                IFA = 0;
                index = 0;
                megVan = false;
                nepesseg = 0;
                do
                {
                    if (item.Hova == varos_data[index].VarosNeve)
                    {
                        nepesseg = (int)varos_data[index].Nepesseg;
                        megVan = true;
                    }
                    index++;
                } while (megVan == false);
                if (nepesseg < 2000000)
                {
                    IFA = 1.05;
                }
                else if (nepesseg < 10000000)
                {
                    IFA = 1.075;
                }
                else
                {
                    IFA = 1.1;
                }
                if (Tulcsordult_ora)
                {
                ment_data.Add(
                    new Menetrend
                    {
                        ID = (uint)c++,
                        RepuloJarat_ID = item.ID,
                        FelszallasIdopontja = FTS,
                        LelszallasIdopontja = LTS,
                        Tulcsordulas = 1,
                        Ara = (uint)Calculate.CalcPrice(item.Tavolsag,item.UtazasiDij,IFA),
                        Ferohely = (uint)rnd.Next(150, 600)
                    }
                    );
                }
                else
                {
                    ment_data.Add(
                    new Menetrend
                    {
                        ID = (uint)c++,
                        RepuloJarat_ID = item.ID,
                        FelszallasIdopontja = FTS,
                        LelszallasIdopontja = LTS,
                        Tulcsordulas = 0,
                        Ara = (uint)Calculate.CalcPrice(item.Tavolsag, item.UtazasiDij, IFA),
                        Ferohely = (uint)rnd.Next(150, 600)
                    }
                    );
                }
                
            };
            modelBuilder.Entity<Menetrend>().HasData(ment_data);
            #endregion
            #region Foglalasok
            //int m = 0;
            //List<Foglalasok> fog_data = new List<Foglalasok> {};
            //foreach (var item in ment_data)
            //{
            //    fog_data.Add(new Foglalasok {
            //        ID = (uint)m++,
            //        Menetrend_ID = item.ID,
            //        JaratDatuma = new DateTime(2023, rnd.Next(1,12), rnd.Next(1, 27), item.FelszallasIdopontja.Hours,item.FelszallasIdopontja.Minutes,item.FelszallasIdopontja.Seconds),
            //        FoglaltHelyek = 0,
            //        FoglalasokOsszege = 0
            //    });
            //    fog_data.Add(new Foglalasok {
            //        ID = (uint)m++,
            //        Menetrend_ID = item.ID,
            //        JaratDatuma = new DateTime(2023, rnd.Next(1,12), rnd.Next(1, 27), item.FelszallasIdopontja.Hours,item.FelszallasIdopontja.Minutes,item.FelszallasIdopontja.Seconds),
            //        FoglaltHelyek = 0,
            //        FoglalasokOsszege = 0
            //    });
            //}
            //modelBuilder.Entity<Foglalasok>().HasData(fog_data);
            #endregion
        }
    }
    public static class Calculate
    {
        //int ora = (int)Math.Truncate((double)item.UtazasiIdo / 60);
        public static int CalcOra(uint UtazasiIdo)
        {
            return (int)Math.Truncate((double)UtazasiIdo / 60);
        }
        //int perc = (int)(item.UtazasiIdo - (ora*60));
        public static int CalcPerc(uint UtazasiIdo,int Ora)
        {
            return (int)(UtazasiIdo - (Ora * 60));
        }
        //Ara = (uint)Math.Truncate(item.Tavolsag * item.UtazasiDij * 1.27 * IFA + (item.Tavolsag / 10)),
        public static uint CalcPrice(uint Tavolsag,uint UtazasiDij, double IFA)
        {
            return (uint)Math.Truncate(Tavolsag * UtazasiDij * 1.27 * IFA + (Tavolsag / 10));
        }
    }
}