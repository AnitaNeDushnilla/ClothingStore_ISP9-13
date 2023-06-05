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
using ClothingStore_ISP9_13.Classes;
using ClothingStore_ISP9_13.BD;
using ClothingStore_ISP9_13.Windows;
using System.Net.Mail;
using ClothingStore_ISP9_13.Pages;
using static ClothingStore_ISP9_13.Classes.NavigationClass;


namespace ClothingStore_ISP9_13.Windows
{
    /// <summary>
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        public EnterWindow()
        {
            InitializeComponent();
        }

      

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            RegWindow regWindow = new RegWindow();
            regWindow.Show();
            this.Close();
            
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var AuthUser = EFClass.Context.User.ToList()
               .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password).FirstOrDefault();


            if (AuthUser != null)
            {
                MessageBox.Show("Вы успешно авторизовались");
                this.Close();

                UserDataClass.User = AuthUser;
                var AuthEmp = EFClass.Context.Employee.Where(i => i.IdUser == AuthUser.Id).FirstOrDefault();
                if (AuthEmp != null)
                {
                    // если не пустой то Работник

                    // сохранияем данные входа

                    UserDataClass.Employee = AuthEmp;

                    // проверка роли 

                    switch (AuthEmp.IdRole)
                    {
                        case 1:
                            // переход на страницу директора
                            MainFrame.Navigate(new ProductPage());
                            this.Close();
                            break;

                        case 2:
                            // переход на страницу администратора
                            break;
                        case 3:
                            // переход на страницу продавца
                            break;
                        default:
                            break;
                    }

                }
                else
                {

                    MainFrame.Navigate(new ProductPage());
                    this.Close();

                }


            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }


        }
    }
}
