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
using ClothingStore_ISP9_13.Classes;

namespace ClothingStore_ISP9_13.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();

            ListEmployee();         
        }

        private void ListEmployee()
        {

            List<Employee> employees = new List<Employee>();
            employees = (List<Employee>)EFClass.Context.Employee.ToList();

            LvEmployee.ItemsSource = employees;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void btnAddEmp_Click(object sender, RoutedEventArgs e)
        {
           AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow();
            addEditEmployeeWindow.ShowDialog();

        }

        private void LvEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Employee selectedEmp = LvEmployee.SelectedItem as Employee;

            AddEditEmployeeWindow addEditEmployeeWindow = new AddEditEmployeeWindow(selectedEmp);
            addEditEmployeeWindow.ShowDialog();
        }
    }
}
