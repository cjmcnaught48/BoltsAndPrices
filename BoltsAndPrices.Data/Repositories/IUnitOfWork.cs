using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoltsAndPrices.Data.Repositories
{
    public partial interface IUnitOfWork : IDisposable
    {
        void Save();

        void Detach(object entity);
        void Copy(object entity);
        void Delete(object entity);
    }
}
