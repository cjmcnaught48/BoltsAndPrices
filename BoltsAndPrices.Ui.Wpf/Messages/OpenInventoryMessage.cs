using BoltsAndPrices.Data.Domain;
using GalaSoft.MvvmLight.Messaging;

namespace BoltsAndPrices.Ui.Wpf.Messages
{
    public class OpenInventoryMessage : MessageBase
    {
        private Inventory _inventory;
        public Inventory Inventory { get { return _inventory; } }

        public OpenInventoryMessage(Inventory inventory)
        {
            _inventory = inventory;
        }

    }

    public class OpenInventoryIndexMessage : MessageBase
    {
        public OpenInventoryIndexMessage()
        {
        }
    }
}
