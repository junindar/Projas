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
  public  class JadwalService: IJadwalService
    {
        private readonly IDapperContext _context;
        private readonly IDbTransaction _transaction;
        public JadwalService(IDapperContext context, IDbTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public void InsertAll(List<Jadwal> listObj)
        {
            string strSQL = @"INSERT INTO Jadwal (kota,ashar,dhuha,dzuhur,imsak,isya,maghrib,subuh,tanggal,terbit)
                VALUES (@kota,@ashar,@dhuha,@dzuhur,@imsak,@isya,@maghrib,@subuh,@tanggal,@terbit)";
            foreach (var itm in listObj)
            {
                _context.Db.Query(strSQL, itm, _transaction,
                    commandType: CommandType.Text);
            }
        }

        public void Insert(Jadwal obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Jadwal obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(Jadwal obj)
        {
            throw new NotImplementedException();
        }

        public List<Jadwal> GetAll()
        {
            throw new NotImplementedException();
        }

        public Jadwal GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Jadwal GetTodayJadwal(string namaKota,string tanggal)
        {
            string strSQL = @"select  * from Jadwal where kota=@namaKota and tanggal=@tanggal";

            return _context.Db.Query<Jadwal>(strSQL, new
                {
                namaKota,
                tanggal
            }, _transaction,
                commandType: CommandType.Text).FirstOrDefault();

        }
    }
}
