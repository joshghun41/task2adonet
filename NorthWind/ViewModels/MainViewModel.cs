using NorthWind.Commands;
using NorthWind.Models;
using NorthWind.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NorthWind.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }


        public ListView listview { get; set; }
        public TextBox StartPrice { get; set; }
        public TextBox EndPrice { get; set; }
        public MainWindow mainWindow { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand AscendingCommand { get; set; }
        public RelayCommand DescendingCommand { get; set; }
        public RelayCommand DefaultCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }
        public RelayCommand lessthan100command { get; set; }
        public RelayCommand greaterthan100command { get; set; }
        public MainViewModel()
        {
            CloseCommand = new RelayCommand((e) =>
            {
                mainWindow.Close();
            });

            DeleteProductCommand = new RelayCommand((e) =>
            {
                var product = listview.SelectedItem as Product;
                ProductRepostory.DeleteProductById(product.Id);
                ProductRepostory.GetAllProducts();
                Products = ProductRepostory.RepoProducts;

            });

          

            AscendingCommand = new RelayCommand((e) =>
            {

                Products = Products.OrderBy(p => p.Price).ToList();
            });


            DescendingCommand = new RelayCommand((e) =>
            {

                Products = Products.OrderByDescending(p => p.Price).ToList();
            });

            DefaultCommand = new RelayCommand((e) =>
            {
                Products = ProductRepostory.RepoProducts;
            });
            lessthan100command = new RelayCommand((e) =>
            {
               Products=Products.Where(p => p.Price <30).ToList();
            });
            greaterthan100command = new RelayCommand((e) =>
            {
               Products = Products.Where(p => p.Price > 30).ToList();
            });

            ProductRepostory.GetAllProducts();
            Products = ProductRepostory.RepoProducts;
        }




    }
}
