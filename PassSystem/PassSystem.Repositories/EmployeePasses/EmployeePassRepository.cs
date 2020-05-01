using PassSystem.Domain.EmployeePasses;
using PassSystem.Repositories.EmployeePasses.DbContexts;
using PassSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PassSystem.Repositories.EmployeePasses
{
    public class EmployeePassRepository : IEmployeePassRepository
    {
        private readonly EmployeePassDbContext _db;

        public EmployeePassRepository(string connectionString)
        {
            _db = new EmployeePassDbContext(connectionString);
        }
        
        public EmployeePass Get(int id)
        {
            return _db.EmployeePasses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EmployeePass> Find(Func<EmployeePass, bool> predicate)
        {
            return _db.EmployeePasses.Where(predicate);
        }

        public IEnumerable<EmployeePass> FindPaged(int page, int countInPage, Func<EmployeePass, bool> predicate)
        {
            var startAt = (page - 1) * countInPage;

            return _db.EmployeePasses.Where(predicate).Skip(startAt).Take(countInPage);
        }

        public void Create(EmployeePass item)
        {
            _db.EmployeePasses.Add(item);
            _db.SaveChanges();
        }

        public void Update(EmployeePass item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var pass = Get(id);
            if (pass != null)
            {
                _db.EmployeePasses.Remove(pass);
                _db.SaveChanges();
            }
        }
        
        IEnumerable<EmployeePass> IEntityRepository<EmployeePass>.GetAll()
        {
            return _db.EmployeePasses.ToArray();
        }

        private Boolean _disposed = false;

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(Boolean disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _db.Dispose();
            }

            _disposed = true;
        }
    }
}