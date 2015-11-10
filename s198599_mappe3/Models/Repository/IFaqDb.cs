using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s198599_mappe3.Models.Repository
{
    public interface IFaqDb<T>
    {
        bool edit(T obj);
        List<T> getList();
        T get(int id);
        bool save(T obj);
        bool delete(int id);
    }
}
