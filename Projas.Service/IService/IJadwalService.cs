using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projas.Service.Entity;

namespace Projas.Service.IService
{
  public  interface IJadwalService : IBaseService<Jadwal>
  {
      Jadwal GetTodayJadwal(string namaKota, string tanggal);
  }
}
