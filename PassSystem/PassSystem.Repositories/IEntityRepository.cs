﻿using System;
using System.Collections.Generic;

namespace PassSystem.Repositories
{
    public interface IEntityRepository<T> : IDisposable where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        IEnumerable<T> FindPaged(int page, int countInPage, Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}