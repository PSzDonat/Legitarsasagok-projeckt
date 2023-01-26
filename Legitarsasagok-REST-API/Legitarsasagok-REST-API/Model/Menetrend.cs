using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace Legitarsasagok_REST_API.Model
{
    public class Menetrend
    {
        public uint ID { get; set; }
        public uint RepuloJarat_ID { get; set; }
        [Column("FelszallasIdopontja ", TypeName = "Time")]
        public TimeSpan FelszallasIdopontja { get; set; }
        [Column("LelszallasIdopontja ", TypeName = "Time")]
        public TimeSpan LelszallasIdopontja { get; set; }
        public uint Tulcsordulas { get; set; }
        public uint Ara { get; set; }
        public uint Ferohely { get; set; }
        public virtual RepuloJaratok RepuloJaratok { get; set; }
        public virtual ICollection<Foglalasok> Foglalasok { get; set; }

        
    }
}
