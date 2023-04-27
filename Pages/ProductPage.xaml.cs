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
using ClothingStore_ISP9_13.BD;
using ClothingStore_ISP9_13.Windows;
using static ClothingStore_ISP9_13.Classes.NavigationClass;



namespace ClothingStore_ISP9_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();

            ListProduct();
        }


        private void ListProduct()
        {
            List<Product> products = new List<Product>();
            products = Classes.EFClass.Context.Product.ToList();

            LvProduct.ItemsSource = products;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProductWindow addEditProduct = new AddEditProductWindow();
            addEditProduct.ShowDialog();

            ListProduct();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            AddEditProductWindow addEditProductWindow = new AddEditProductWindow(selectedProduct);
            addEditProductWindow.ShowDialog();

            ListProduct();

        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EmployeePage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

