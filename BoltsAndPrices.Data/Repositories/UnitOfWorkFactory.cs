
namespace BoltsAndPrices.Data.Repositories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new Domain.BoltsAndPricesContext());
        }
    }
}
