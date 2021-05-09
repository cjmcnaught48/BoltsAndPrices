using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Models;
using BoltsAndPrices.Infrastructure.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{



    public class InventoryEditViewModel : ViewModelBase, IInventoryModel
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;
        public InventoryEditViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public int? InventoryId { get; set; }

        private string _inventoryCode;
        public string InventoryCode 
        { 
            get
            {
                return _inventoryCode;
            }
            set
            {
                _inventoryCode = value;
                this.RaisePropertyChanged(() => this.InventoryCode);
            }
        }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                this.RaisePropertyChanged(() => this.Price);
            }
        }
        
        public RelayCommand SaveInventoryCommand => new RelayCommand(() =>
        {
            SaveInventory();
        });

        private string _statusDescription;
        public string StatusDescription
        {
            get
            {
                return _statusDescription;
            }
            set
            {
                _statusDescription = value;
                this.RaisePropertyChanged(() => this.StatusDescription);
            }
        }

        public bool Status { get; set; }

        public void SaveInventory()
        {
            StatusDescription = string.Empty;

            using(var unitOfWork =_unitOfWorkFactory.Create())
            {
                try
                {
                    new InventoryService(unitOfWork).AddOrUpdate(this);

                    Status = true;
                    StatusDescription = "Saved.";

                }
                catch (Exception e)
                {
                    Status = false;
                    StatusDescription = "An Error Occurred trying to save changes.";
                }
            }
        }

    }
}
