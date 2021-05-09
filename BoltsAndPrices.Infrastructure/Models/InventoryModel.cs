namespace BoltsAndPrices.Infrastructure.Models
{
    public interface IInventoryModel
    {
        int? InventoryId { get; }
        string InventoryCode { get; }
        double Price { get; }
    }

    public static class IInventoryModelExtensions
    { 
        public static bool Exists(this IInventoryModel inventoryModel)
        {
            return inventoryModel.InventoryId != null;
        }
    }
}
