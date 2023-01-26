using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Legitarsasagok_REST_API.Model
{
    public class Foglalasok
    {
        public uint ID { get; set; }
        public uint Menetrend_ID { get; set; }
        [Column("JaratDatuma ", TypeName = "Date")]
        public DateTime JaratDatuma { get; set; }
        public uint FoglaltHelyek { get; set; }
        public uint FoglalasokOsszege { get; set; }
        public virtual Menetrend Menetrend { get; set; }

    }
}
