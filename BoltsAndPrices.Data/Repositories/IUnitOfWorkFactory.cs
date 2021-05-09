namespace BoltsAndPrices.Data.Repositories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
