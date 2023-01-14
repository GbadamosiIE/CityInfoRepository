using CityInfo.Core.IRepositories;
using CityInfo.Core.IUnitOfWork;
using CityInfo.Infrastructure.CityContext;
using CityInfo.Infrastructure.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CityInfoContext _context;
        private ICityInfoRepository _cityInfoRepository;
        private bool _disposed;

        public UnitOfWork(CityInfoContext context)
        {
            _context = context;
        }

        public ICityInfoRepository cityInfoRepository =>
            _cityInfoRepository ??= new CityInfoRepository();
        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }
        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
