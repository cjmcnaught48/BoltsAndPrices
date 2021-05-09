using BoltsAndPrices.Data.Domain;

namespace BoltsAndPrices.Data.Repositories
{
    public partial interface IUnitOfWork
    {
        Repository<Inventory> Inventory { get; }
        Repository<Invoice> Invoice { get; }
        Repository<InvoiceInventory> InvoiceInventory { get; }
    }
}
