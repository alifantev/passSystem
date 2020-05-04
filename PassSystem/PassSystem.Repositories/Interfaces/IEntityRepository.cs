using System;
using System.Collections.Generic;
using PassSystem.Tools;

namespace PassSystem.Repositories.Interfaces
{
    public interface IEntityRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        PagedData<T> FindPaged(int page, int countInPage, Func<T, Boolean> predicate);
        int Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}