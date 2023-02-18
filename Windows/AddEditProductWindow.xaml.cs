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
using System.Windows.Shapes;
using ClothingStore_ISP9_13.BD;
using ClothingStore_ISP9_13.Windows;
using ClothingStore_ISP9_13.Classes;

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

            cmbSize.ItemsSource = EFClass.Context.Manufacturer.ToList();
            cmbSize.SelectedIndex = 0;
            cmbSize.DisplayMemberPath = "Size";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
