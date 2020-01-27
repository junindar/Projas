using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.IService
{
  public  interface IUnitOfWork
    {
        ICityService cityService { get; }
        IJadwalService jadwalService { get; }
        ISettingService settingService { get; }
        void BeginTransaction();
        void Commit();
    }
}
