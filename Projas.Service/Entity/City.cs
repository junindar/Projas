using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.Entity
{
  public  class City
    {
        public int id { get; set; }
        public string nama { get; set; }
    }

  public class Cities
  {
      public List<City> Kota { get; set; }
  }
}
