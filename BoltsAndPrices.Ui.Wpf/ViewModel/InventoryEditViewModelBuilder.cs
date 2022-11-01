using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;
using BoltsAndPrices.Infrastructure.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    public class InventoryEditViewModelBuilder
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        public InventoryEditViewModelBuilder(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public InventoryEditViewModel Build(Inventory inventory)
        {
            var model = new InventoryEditViewModel(_unitOfWorkFactory);

            model.InventoryId = inventory.InventoryId;
            model.InventoryCode = inventory.InventoryCode;
            model.Price = inventory.Price;

            return model;
        }

        public InventoryEditViewModel Build()
        {
            var model = new InventoryEditViewModel(_unitOfWorkFactory);
            return model;
        }
    }
}
