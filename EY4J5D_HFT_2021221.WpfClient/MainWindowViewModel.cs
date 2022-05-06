using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EY4J5D_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EY4J5D_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Model> Models { get; set; }
        public ICommand CreateModelCommand { get; set; }
        public ICommand UpdateModelCommand { get; set; }
        public ICommand DeleteModelCommand { get; set; }
        private Model selectedModel;

        public Model SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (value != null)
                {
                    selectedModel = new Model()
                    {
                        Model_Name = value.Model_Name,
                        Id = value.Id, 
                        Brand_Id = value.Brand_Id, 
                        Purchases = value.Purchases != null ? value.Purchases : new List<Purchase>(),
                        Brand = value.Brand != null ? value.Brand : new Brand()
                    };
                }
                OnPropertyChanged();
                (DeleteModelCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateModelCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public RestCollection<Brand> Brands { get; set; }
        public ICommand CreateBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Brand_Name = value.Brand_Name,
                        Id = value.Id, 
                        Models = value.Models != null ? value.Models : new List<Model>()
                    };
                }
                OnPropertyChanged();
                (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateBrandCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public RestCollection<Purchase> Purchases { get; set; }
        public ICommand CreatePurchaseCommand { get; set; }
        public ICommand UpdatePurchaseCommand { get; set; }
        public ICommand DeletePurchaseCommand { get; set; }
        private Purchase selectedPurchase;

        public Purchase SelectedPurchase
        {
            get { return selectedPurchase; }
            set
            {
                if (value != null)
                {
                    selectedPurchase = new Purchase()
                    {
                        Id = value.Id, 
                        Model = value.Model != null ? value.Model : new Model() , 
                        Model_Id = value.Model_Id, 
                        Price = value.Price,
                        Purchase_Date = value.Purchase_Date != null ? value.Purchase_Date : DateTime.Now
                    };
                }
                OnPropertyChanged();
                (DeletePurchaseCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdatePurchaseCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Models = new RestCollection<Model>("http://localhost:3445/", "model", "hub");
                CreateModelCommand = new RelayCommand(() => { Models.Add(new Model() { Brand_Id = 1, Model_Name = SelectedModel.Model_Name, Purchases = SelectedModel.Purchases }); });
                UpdateModelCommand = new RelayCommand(() => { Models.Update(SelectedModel); }, () => { return SelectedModel != null; });
                DeleteModelCommand = new RelayCommand(() => { Models.Delete(SelectedModel.Id); }, () => { return SelectedModel != null; });
                Brands = new RestCollection<Brand>("http://localhost:3445/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() => { Brands.Add(new Brand() { Brand_Name = SelectedBrand.Brand_Name, Models = SelectedBrand.Models }); });
                UpdateBrandCommand = new RelayCommand(() => { Brands.Update(SelectedBrand); }, () => { return SelectedBrand != null; });
                DeleteBrandCommand = new RelayCommand(() => { Brands.Delete(SelectedBrand.Id); }, () => { return SelectedBrand != null; });

                Purchases = new RestCollection<Purchase>("http://localhost:3445/", "purchase", "hub");
                CreatePurchaseCommand = new RelayCommand(() => { Purchases.Add(new Purchase() { Model_Id = SelectedPurchase.Model_Id, Price = SelectedPurchase.Price, Purchase_Date = SelectedPurchase.Purchase_Date }); });
                UpdatePurchaseCommand = new RelayCommand(() => { Purchases.Update(SelectedPurchase); }, () => { return SelectedPurchase != null; });
                DeletePurchaseCommand = new RelayCommand(() => { Purchases.Delete(SelectedPurchase.Id); }, () => { return SelectedPurchase != null; });
                SelectedBrand = new Brand(); 
                SelectedModel = new Model(); 
                SelectedPurchase = new Purchase();
            }
        }
    }
}
