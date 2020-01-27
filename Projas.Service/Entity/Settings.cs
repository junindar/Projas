using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.Entity
{
    public class Settings
    {
        public int id { get; set; }
        public string NamaKota { get; set; }
        public string NamaMasjid { get; set; }
        public string Alamat { get; set; }
        public string Keterangan { get; set; }
        public int DurasiSubuh { get; set; }
        public int DurasiDzuhur { get; set; }
        public int DurasiAshar { get; set; }
        public int DurasiMaghrib { get; set; }
        public int DurasiIsya { get; set; }

    }
}
