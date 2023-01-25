using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legitarsasagok_Wpf.Model
{
    public class RepuloJaratok
    {
        public uint ID { get; set; }
        public string Legitarsasag { get; set; }
        public string Honnan { get; set; }
        public string Hova { get; set; }
        public uint Tavolsag { get; set; }
        public uint UtazasiIdo { get; set; }
        public uint UtazasiDij { get; set; }
        //public virtual ICollection<Menetrend> Menetrend { get; set; }
        //public virtual Varosok Varosok { get; set; }
    }
    public class RepuloJaratokTime
    {
        public uint ID { get; set; }
        public string Legitarsasag { get; set; }
        public string Honnan { get; set; }
        public string Hova { get; set; }
        public uint Tavolsag { get; set; }
        public string UtazasiIdo { get; set; }
        public uint UtazasiDij { get; set; }
        //public virtual ICollection<Menetrend> Menetrend { get; set; }
        //public virtual Varosok Varosok { get; set; }
    }
}
