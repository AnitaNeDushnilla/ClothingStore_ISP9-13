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
        private string pathImage = null;
        private bool isEdit = false;
        Product editProduct;

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
            cmbSize.DisplayMemberPath = "Name";

            cmbColor.ItemsSource = EFClass.Context.Color.ToList();
            cmbColor.SelectedIndex = 0;
            cmbColor.DisplayMemberPath = "ColorName";
        }

        public AddEditProductWindow(Product product)
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
            cmbSize.DisplayMemberPath = "Name";

            cmbColor.ItemsSource = EFClass.Context.Color.ToList();
            cmbColor.SelectedIndex = 0;
            cmbColor.DisplayMemberPath = "ColorName";

            tbName.Text = product.Name;
            tbCost.Text = product.Cost.ToString();
            cmbManufacturer.SelectedItem = EFClass.Context.Manufacturer.ToList().Where(i => i.Id == product.IdManufacturer).FirstOrDefault();
            cmbGender.SelectedItem = EFClass.Context.Gender.ToList().Where(i => i.Id == product.IdGender).FirstOrDefault();
            cmbSize.SelectedItem = EFClass.Context.Size.ToList().Where(i => i.Id == product.IdSize).FirstOrDefault();
            cmbColor.SelectedItem = EFClass.Context.Color.ToList().Where(i => i.Id == product.IdColor).FirstOrDefault();


            if (product.Image != null)
            {
                using (MemoryStream ms = new MemoryStream(product.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    imgPhoto.Source = bitmapImage;
                }
            }
            tbLabel.Text = "~ Изменение товара ~";
            btnAdd.Content = "Изменить";
            isEdit = true;
            editProduct = product;
        }



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
            if (isEdit)
            {
                // редактирование

                editProduct.Name = tbName.Text;
                editProduct.Cost = Convert.ToDecimal(tbCost.Text);
                editProduct.Quantity = Convert.ToInt32(tbQuantity.Text);
                editProduct.IdManufacturer = (cmbManufacturer.SelectedItem as Manufacturer).Id;
                editProduct.IdGender = (cmbGender.SelectedItem as Gender).Id;
                editProduct.IdSize = (cmbSize.SelectedItem as BD.Size).Id;
                editProduct.IdColor = (cmbColor.SelectedItem as BD.Color).Id;

                if (pathImage != null)
                {
                    editProduct.Image = File.ReadAllBytes(pathImage);
                }

                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                Product product = new Product();
                product.Name = tbName.Text;
                product.Quantity = Convert.ToInt32(tbQuantity.Text);
                product.Cost = Convert.ToDecimal(tbCost.Text);
                product.IdManufacturer = (cmbManufacturer.SelectedItem as Manufacturer).Id;
                product.IdGender = (cmbGender.SelectedItem as Gender).Id;
                product.IdSize = (cmbSize.SelectedItem as BD.Size).Id;
                product.IdColor = (cmbColor.SelectedItem as BD.Color).Id;

                if (pathImage != null)
                {
                    product.Image = File.ReadAllBytes(pathImage);
                }

                EFClass.Context.Product.Add(product);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно добавлен");
            }
            this.Close();
            
        }
    }
}
