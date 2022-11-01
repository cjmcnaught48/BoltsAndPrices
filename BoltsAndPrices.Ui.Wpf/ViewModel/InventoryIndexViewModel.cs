using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BoltsAndPrices.Data.Domain;
using BoltsAndPrices.Data.Repositories;
using BoltsAndPrices.Infrastructure.Services;
using System.Linq;
using BoltsAndPrices.Ui.Wpf.Messages;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InventoryIndexViewModel : ViewModelBase
    {
        private IUnitOfWorkFactory _unitOfWorkFactory;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public InventoryIndexViewModel(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;

            Inventories = new ObservableCollection<Inventory>(GetInventory());

            Messenger.Default.Register<InventoryUpdatedMessage>(this, InventoryUpdated);

        }
        
        private void InventoryUpdated(InventoryUpdatedMessage message)
        {
            Inventories = new ObservableCollection<Inventory>(GetInventory(SearchTerm));
        }


        private ObservableCollection<Inventory> _inventories;
        public ObservableCollection<Inventory> Inventories
        { 
            get 
            { 
                return _inventories; 
            } 
            set 
            {
                _inventories = value;
                this.RaisePropertyChanged(() => this.Inventories);
            } 
        }

        public string SearchTerm { get; set; }

        public Inventory SelectedInventory { get; set; }

        public RelayCommand SearchCommand => new RelayCommand(() => 
        {
            Inventories = new ObservableCollection<Inventory>(GetInventory(SearchTerm));
        });

        public RelayCommand ShowInventoryCommand => new RelayCommand(() =>
        {
            if(SelectedInventory != null)
            {
                Messenger.Default.Send(new OpenInventoryMessage(SelectedInventory));
            }      
        });

        public RelayCommand AddInventoryCommand => new RelayCommand(() =>
        {
            Messenger.Default.Send(new AddInventoryMessage());
        });


        private IEnumerable<Inventory> GetInventory(string searchTerm = null)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                var service = new InventoryService(unitOfWork);

                if(string.IsNullOrWhiteSpace(searchTerm))
                {
                    return service.GetInventories().ToList();
                }

                return service.GetInventories(searchTerm).ToList();
            }
        }
    }
}