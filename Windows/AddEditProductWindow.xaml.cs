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
using System.IO;
using System.Windows.Shapes;
using ClothingStore_ISP9_13.BD;
using ClothingStore_ISP9_13.Windows;
using ClothingStore_ISP9_13.Classes;
using Microsoft.Win32;

namespace ClothingStore_ISP9_13.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        public AddEditProductWindow()
        {
            InitializeComponent();

            cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "GenderName";

            cmbManufacturer.ItemsSource = EFClass.Context.Manufacturer.ToList();
            cmbManufacturer.SelectedIndex = 0;
            cmbManufacturer.DisplayMemberPath = "Name";

            cmbSize.ItemsSource = EFClass.Context.Size.ToList();
            cmbSize.SelectedIndex = 0;
            cmbSize.DisplayMemberPath = "Size";
        }
        private string pathImage = null;
        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            product.Name = tbName.Text;
            product.Quantity = Convert.ToInt32(tbQuantity.Text);
            product.Cost = Convert.ToDecimal(tbCost.Text);
            product.IdManufacturer = (cmbManufacturer.SelectedItem as Manufacturer).Id;
            if (pathImage != null)
            {
                product.Image = File.ReadAllBytes(pathImage);
            }

            EFClass.Context.Product.Add(product);
            EFClass.Context.SaveChanges();

            MessageBox.Show("Товар успешно добавлен");
            this.Close();
        }
    }
}
