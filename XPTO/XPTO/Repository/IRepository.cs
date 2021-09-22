using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPTO.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        List<T> GetAll();
        T GetById(object id);
        void Deletar(object id);
        void Save();
    }
}
