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
  public  class CityService : ICityService
    {
        private readonly IDapperContext _context;
        private readonly IDbTransaction _transaction;
        public CityService(IDapperContext context, IDbTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }
        public void InsertAll(List<City> listObj)
        {

            string strSQL = @"INSERT INTO City (nama) VALUES (@nama)";
            foreach (var itm in listObj)
            {
                _context.Db.Query(strSQL, itm, _transaction,
                    commandType: CommandType.Text);
            }

        }

        public void Insert(City obj)
        {
            throw new NotImplementedException();
        }

        public void Update(City obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(City obj)
        {
            throw new NotImplementedException();
        }

        public List<City> GetAll()
        {
            string strSQL = @"select  * from City order by id asc";
            return _context.Db.Query<City>(strSQL, _transaction,
                commandType: CommandType.Text).ToList();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
