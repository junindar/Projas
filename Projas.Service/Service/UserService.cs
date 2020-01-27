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
 public   class UserService : IUserService
    {

        private readonly IDapperContext _context;
        private readonly IDbTransaction _transaction;
        public UserService(IDapperContext context, IDbTransaction transaction)
        {
            _context = context;
            _transaction = transaction;
        }

        public void InsertAll(List<User> listObj)
        {
            throw new NotImplementedException();
        }

        public void Insert(User obj)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            string strSQL = @"Update Users set [Password]=@Password";

            _context.Db.Query(strSQL, obj, _transaction,
                commandType: CommandType.Text);
        }

        public void Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            string strSQL = @"select  * from Users order by Username asc limit 1";

            return _context.Db.Query<User>(strSQL, _transaction,
                commandType: CommandType.Text).FirstOrDefault();
        }
    }
}
