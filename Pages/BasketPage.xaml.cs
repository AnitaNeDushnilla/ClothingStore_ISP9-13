using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClothingStore_ISP9_13.Windows;
using static ClothingStore_ISP9_13.Classes.NavigationClass;
using ClothingStore_ISP9_13.Classes;
using ClothingStore_ISP9_13.Pages;
using ClothingStore_ISP9_13.BD;

namespace ClothingStore_ISP9_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для BasketPage.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        public BasketPage()
        {
            InitializeComponent();

            GetListProduct();
        }
       
        private void GetListProduct()
        {
            LvBasket.ItemsSource = BasketClass.products;
            
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
            
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;
            
            BasketClass.products.Remove(selectedProduct);
            
            GetListProduct();
        }
    }
}
