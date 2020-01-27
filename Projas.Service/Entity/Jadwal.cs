using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.Entity
{
  public  class Jadwal
    {
        public int id { get; set; }
        public string kota { get; set; }
        public string ashar { get; set; }
        public string dhuha { get; set; }
        public string dzuhur { get; set; }
        public string imsak { get; set; }
        public string isya { get; set; }
        public string maghrib { get; set; }
        public string subuh { get; set; }
        public string tanggal { get; set; }
      
        public string terbit { get; set; }
    }

  public class JadwalData
  {
      public Jadwal data { get; set; }
    }

    public class Schedules
    {
        
        public JadwalData jadwal { get; set; }
    }

}
