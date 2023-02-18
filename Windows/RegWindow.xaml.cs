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
using ClothingStore_ISP9_13.Classes;
using ClothingStore_ISP9_13.Windows;

namespace ClothingStore_ISP9_13.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
            cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
            cmbGender.SelectedIndex = 0;
            cmbGender.DisplayMemberPath = "GenderName";
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            EnterWindow enterWindow = new EnterWindow();
            enterWindow.Show();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbLogin.Text))
            {
                MessageBox.Show("Поле Логин не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(pbPass.Password))
            {
                MessageBox.Show("Поле Пароль не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbFirstName.Text.Contains("1") | tbFirstName.Text.Contains("2") | tbFirstName.Text.Contains("3") | tbFirstName.Text.Contains("4") | tbFirstName.Text.Contains("5")
                | tbFirstName.Text.Contains("6") | tbFirstName.Text.Contains("7") | tbFirstName.Text.Contains("8") | tbFirstName.Text.Contains("9") | tbFirstName.Text.Contains("0"))
            {
                MessageBox.Show("Поле Имя не должно содержать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbLastName.Text.Contains("1") | tbLastName.Text.Contains("2") | tbLastName.Text.Contains("3") | tbLastName.Text.Contains("4") | tbLastName.Text.Contains("5")
               | tbLastName.Text.Contains("6") | tbLastName.Text.Contains("7") | tbLastName.Text.Contains("8") | tbLastName.Text.Contains("9") | tbLastName.Text.Contains("0"))
            {
                MessageBox.Show("Поле Фамилия не должно содержать цифры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }        
            if (tbPhone.Text.Length != 11)
            {
                MessageBox.Show("Неверный формат телефона", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var a1 = tbEmail.Text.Split('@');
            if (a1.Length == 2)
            {
                var a2 = a1[1].Split('.');
                if (a2.Length == 2)
                {

                }
                else
                {
                    MessageBox.Show("Неверный формат Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Неверный формат Email", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!dpBirthday.SelectedDate.HasValue)
            {
                MessageBox.Show("Не введена дата рождения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EFClass.Context.User.Add(new User()
            {
                Login = tbLogin.Text,
                Password = pbPass.Password,
                LastName = tbLastName.Text,
                FirtsName = tbFirstName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
                Birthday = dpBirthday.SelectedDate.Value,
                IdGender = (cmbGender.SelectedItem as Gender).Id,
                IdRole = 3

            });

            EFClass.Context.SaveChanges();

            MessageBox.Show("Вы успешно зарегистрировались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
