/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BoltsAndPrices.Ui.Wpf"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using BoltsAndPrices.Data.Repositories;

namespace BoltsAndPrices.Ui.Wpf.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<InventoryIndexViewModel>();
            SimpleIoc.Default.Register<InvoiceIndexViewModel>();
            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }

        public InvoiceIndexViewModel InvoiceIndexViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InvoiceIndexViewModel>();
            }
        }

        public InventoryIndexViewModel InventoryIndexViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InventoryIndexViewModel>();
            }
        }

        public MainWindowViewModel MainWindowViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            }
        }        

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}