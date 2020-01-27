using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Projas.Service.Entity;
using Projas.Service.IService;

namespace Projas.Service.Service
{
  public  class SettingService:ISettingService
    {
        private readonly IDapperContext _context;
        private readonly IDbTransaction _transaction;
        public SettingService(IDapperContext context, IDbTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public void InsertAll(List<Settings> listObj)
        {
            throw new NotImplementedException();
        }

        public void Insert(Settings obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Settings obj)
        {
            string strSQL = @"Update Settings set NamaKota=@NamaKota,NamaMasjid=@NamaMasjid,Alamat=@Alamat,Keterangan=@Keterangan";
           
                _context.Db.Query(strSQL, obj, _transaction,
                    commandType: CommandType.Text);
           
        }

        public void Delete(Settings obj)
        {
            throw new NotImplementedException();
        }

        public List<Settings> GetAll()
        {
            throw new NotImplementedException();
        }

        public Settings GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDurasi(Settings obj)
        {
            string strSQL = @"Update Settings set DurasiSubuh=@DurasiSubuh,DurasiDzuhur=@DurasiDzuhur,
                DurasiAshar=@DurasiAshar,DurasiMaghrib=@DurasiMaghrib,DurasiIsya=@DurasiIsya";

            _context.Db.Query(strSQL, obj, _transaction,
                commandType: CommandType.Text);

        }

        public Settings GetTop1()
        {
            string strSQL = @"select  * from Settings order by id asc limit 1";
            return _context.Db.Query<Settings>(strSQL, _transaction,
                commandType: CommandType.Text).FirstOrDefault();
        }
    }
}
