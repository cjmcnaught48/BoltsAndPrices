namespace BoltsAndPrices.Data.Domain
{
    public class InvoiceInventory
    { 
        public int InvoiceInventoryId { get; set; }

        public int InvoiceId { get; set; }

        public int InventoryId { get; set; }

        public int Quantity { get; set; }


        public double UnitPrice { get; set; }

        public double LineTotal { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Inventory Inventory { get; set; }

    }
}
