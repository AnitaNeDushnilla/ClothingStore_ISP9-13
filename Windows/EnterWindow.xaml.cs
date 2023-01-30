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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var AuthUser = EFClass.Context.User.ToList()
                .Where(i => i.Login == tbLogin.Text && i.Password == pbPass.Password).FirstOrDefault();
            if (AuthUser != null)
            {
                MessageBox.Show("Вы успешно авторизовались");
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }


        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();
        }
    }
}
