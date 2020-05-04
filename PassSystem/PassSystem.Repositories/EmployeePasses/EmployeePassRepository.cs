using PassSystem.Domain.EmployeePasses;
using PassSystem.Repositories.EmployeePasses.DbContexts;
using PassSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PassSystem.Tools;

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
            return _db.EmployeePasses.Include(x => x.Employee).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EmployeePass> Find(Func<EmployeePass, bool> predicate)
        {
            return _db.EmployeePasses.Include(x => x.Employee).Where(predicate);
        }

        public PagedData<EmployeePass> FindPaged(int page, int countInPage, Func<EmployeePass, bool> predicate)
        {
            var startAt = (page - 1) * countInPage;
            var totalRows = _db.EmployeePasses.Include(x => x.Employee).Where(predicate).Count();
            var items = _db.EmployeePasses
                .Include(x => x.Employee)
                .Where(predicate)
                .Skip(startAt).Take(countInPage);
            
            return new PagedData<EmployeePass>()
            {
                TotalRows = totalRows,
                Items = items
            };
        }

        public int Create(EmployeePass item)
        {
            _db.EmployeePasses.Add(item);
            _db.SaveChanges();

            return item.Id;
        }

        public void Update(EmployeePass item)
        {
            var entity = _db.EmployeePasses.Include(x => x.Employee).Where(x => x.Id == item.Id).AsQueryable().FirstOrDefault();
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            
            _db.Entry(entity).State = EntityState.Modified;
            _db.Entry(entity).CurrentValues.SetValues(item);
            _db.Entry(entity.Employee).CurrentValues.SetValues(item.Employee);
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
            return _db.EmployeePasses.Include(x => x.Employee).ToArray();
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