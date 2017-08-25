using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi.Infrastructure
{
    public interface IDbController<T>
    {
        List<T> Index();
        T Details(int id);
        T Create();
        T Create(T book);
        T Edit(int id);
        T Edit(int id, T book);
        T Delete(int id);
        T Delete(int id, T book);
    }
}
