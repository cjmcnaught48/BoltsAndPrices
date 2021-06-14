using BoltsAndPrices.Data.Domain;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InventorySelectModel
    {
        public InventorySelectModel()
        {

        }

        public InventorySelectModel(Inventory inventory)
        {
            InventoryId = inventory.InventoryId;
            InventoryCode = inventory.InventoryCode;
            Price = inventory.Price;
        }

        public int InventoryId { get; set; }
        public string InventoryCode { get; set; }
        public double Price { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                InventorySelectModel p = (InventorySelectModel)obj;
                return (InventoryId == p.InventoryId);
            }
        }

        public override int GetHashCode()
        {
            return InventoryId;
        }

    }
}
