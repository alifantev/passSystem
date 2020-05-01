using PassSystem.Domain.EmployeePasses;
using System;
using System.Collections.Generic;


namespace PassSystem.Repositories.EmployeePasses
{
    internal class EmployeePassRepository : IEntityRepository<EmployeePass>
    {
        private readonly EmployeePassDbContext _db;

        public EmployeePassRepository(string connectionString)
        {
            _db = new EmployeePassDbContext(connectionString);
        }
        
//        internal void Add(EmployeePass employeePass)
//        {
//            using (var db = new EmployeePassDbContext())
//            {
//                db.EmployeePasses.Add(employeePass);
//                db.SaveChanges();
//            }
//        }
//
//        internal EmployeePass[] GetAll()
//        {
//            using (var db = new EmployeePassDbContext())
//            {
//                return db.EmployeePasses.Include(x => x.Employee).ToArray();
//            }
//        }

        public EmployeePass Get(int id)
        {
            return _db.EmployeePasses.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EmployeePass> Find(Func<EmployeePass, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeePass> FindPaged(int page, int countInPage, Func<EmployeePass, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(EmployeePass item)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeePass item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        IEnumerable<EmployeePass> IEntityRepository<EmployeePass>.GetAll()
        {
            return GetAll();
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