using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projas.Service.IService
{
  public  interface IBaseService<T> where T : class
    {
        void InsertAll(List<T> listObj);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        List<T> GetAll();
        T GetById(int id);
    }
}
