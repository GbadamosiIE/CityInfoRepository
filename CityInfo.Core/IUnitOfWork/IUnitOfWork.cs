using CityInfo.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo.Core.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ICityInfoRepository cityInfoRepository { get; }

        void SaveChanges();

        void BeginTransaction();

        void Rollback();
        Task SaveChangesAsync();
    }
}
