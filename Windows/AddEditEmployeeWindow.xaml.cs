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
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private bool isEdit = false;
        Employee editEmployee;

        public AddEditEmployeeWindow()
        {
            InitializeComponent();

            cmbRole.ItemsSource = EFClass.Context.Role.ToList();
            cmbRole.SelectedIndex = 0;
            cmbRole.DisplayMemberPath = "RoleName";
        }

        public AddEditEmployeeWindow(Employee employee)
        {
            InitializeComponent();

            cmbRole.ItemsSource = EFClass.Context.Role.ToList();
            cmbRole.SelectedIndex = 0;
            cmbRole.DisplayMemberPath = "RoleName";

            tbFirstName.Text = employee.User.FirtsName;
            tbLastName.Text = employee.User.LastName;
            tbPhone.Text = employee.User.Phone;
            tbLogin.Text = employee.User.Login;
            pbPass.Password = employee.User.Password;
            dpBirthday.Text = employee.User.Birthday.ToString();
            cmbRole.SelectedItem = EFClass.Context.Role.ToList().Where(i => i.Id == employee.IdRole).FirstOrDefault();


            tbLabel.Text = "~ Изменение сотрудника ~";
            btnAdd.Content = "Изменить";
            isEdit = true;
            editEmployee = employee;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                editEmployee.User.FirtsName = tbFirstName.Text;
                editEmployee.User.LastName = tbLastName.Text;
                editEmployee.User.Phone = tbPhone.Text;
                editEmployee.User.Login = tbLogin.Text;
                editEmployee.User.Password = pbPass.Password;
                editEmployee.User.Birthday = dpBirthday.SelectedDate.Value;
                editEmployee.IdRole = (cmbRole.SelectedItem as Role).Id;


                EFClass.Context.SaveChanges();

                MessageBox.Show("Сотрудник успешно изменен");
            }
            else
            {
                Employee employee = new Employee();
                employee.User.FirtsName = tbFirstName.Text;
                employee.User.LastName = tbLastName.Text;
                employee.User.Phone = tbPhone.Text;
                employee.User.Login = tbLogin.Text;
                employee.User.Password = pbPass.Password;
                employee.User.Birthday = dpBirthday.SelectedDate.Value;
                employee.IdRole = (cmbRole.SelectedItem as Role).Id;
            
                EFClass.Context.Employee.Add(employee);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Сотрудник успешно добавлен");
            }
            this.Close();
        }
    }
}
