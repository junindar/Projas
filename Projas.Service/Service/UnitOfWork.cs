using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projas.Service.IService;

namespace Projas.Service.Service
{
  public  class UnitOfWork : IUnitOfWork
    {
        private readonly IDapperContext _context;
        private IDbTransaction _transaction;
        private ICityService _cityService;
        private IJadwalService _jadwalService;
        private ISettingService _settingService;
        public UnitOfWork(IDapperContext context)
        {
            _context = context;
        }

        public ICityService cityService
            => _cityService ?? (_cityService = new CityService(_context, _transaction));
        public IJadwalService jadwalService =>
            _jadwalService ?? (_jadwalService = new JadwalService(_context, _transaction));

        public ISettingService settingService =>
            _settingService ?? (_settingService = new SettingService(_context, _transaction));

        public void BeginTransaction()
        {
            if (_transaction != null)
                throw new NullReferenceException("Not finished previous transaction");

            _transaction = _context.Db.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
                throw new NullReferenceException("Tryed commit not opened transaction");

            _transaction.Commit();
        }
    }
}
