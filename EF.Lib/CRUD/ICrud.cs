using System.Collections.Generic;

namespace EF.Lib.CRUD
{
    public interface ICrud<T>
    {
        public void Add(T obj);
        public void Update(T obj);
        public void Delete(T obj);
        public List<T> ReadAll();
    }
}