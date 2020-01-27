using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Projas.Service.IService;

namespace Projas.Service.Service
{
  public  class DapperContext : IDapperContext
    {
        private readonly string _providerName;
        private readonly string _connectionString;
        private IDbConnection _db;

        public DapperContext()
        {
            _providerName = "System.Data.SQLite";
            var location = Assembly.GetExecutingAssembly().Location;
            if (string.IsNullOrEmpty(location)) return;
            var path = Path.GetDirectoryName(location);
            if (!string.IsNullOrEmpty(path))
            {
                _connectionString = "Data Source = " + Path.Combine(path, "projas.DB") ;
               
            }


        }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    if (_db.State != ConnectionState.Closed)
                        _db.Close();
                }
                finally
                {
                    _db.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }

        private IDbConnection GetOpenConnection(string providerName, string connectionString)
        {
            DbConnection conn;

            try
            {
                DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);
                conn = provider.CreateConnection();
                if (conn != null)
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                }
            }
            catch (DbException sqlEx)
            {
                throw new Exception(sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conn;
        }
        public IDbConnection Db => _db ?? (_db = GetOpenConnection(_providerName, _connectionString));

    }
}
