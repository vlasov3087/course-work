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
using TCPConnectionAPIClientModule_C_sharp_;

namespace Front_End_Three
{
    /// <summary>
    /// Логика взаимодействия для FindAdmin.xaml
    /// </summary>
    public partial class FindAdmin : Window
    {
        int counter = 0;
        ParamToFindUser choosenParam;
        bool isEmpty = true;
        private IAdminAccess module;
        List<DatabaseEntities.Admin> admins;
        DatabaseEntities.Admin adminBuffer;
        public FindAdmin(IAdminAccess module)
        {
            choosenParam = ParamToFindUser.Login;
            this.module = module;
            admins = module.GetAllAdmins();
            InitializeComponent();
            if (admins == null || admins.Count == 0 )
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(admins[0]);
        }


        private void FindAdmin_Click(object sender, RoutedEventArgs e)
        {
            admins.Clear();
            switch (choosenParam)
            {
                case ParamToFindUser.Login:
                    {
                        adminBuffer = module.FindAdminByLogin(AdminLogin.Text);
                        admins.Add(adminBuffer);
                        break;
                    }
                case ParamToFindUser.None:
                    {
                        admins = module.GetAllAdmins();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }

            if (admins.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                Show(admins[0]);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                DataInput.Text = "";
                isEmpty = false;
            }
        }
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (admins.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(admins[0]);
                }
                else
                {
                    counter--;
                    Show(admins[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (admins.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if(admins.Count == 1)
            {
                Show(admins[counter]);
            }
            else
            {
                if (counter + 1 == admins.Count)
                {
                    Show(admins[counter]);
                }
                else
                {
                    counter++;
                    Show(admins[counter]);
                }
            }
        }

        private void Show(DatabaseEntities.Admin admin)
        {
            if (admin == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                AdminImage.Source = App.ConvertToBitmapImage(admin.Photo);
                AdminLogin.Text = admin.Login;
                AdminStatus.Text = admin.UserStatus.ToString();
                if (admin.IsOnline)
                {
                    AdminLastOnline.Text = "В сети";
                }
                else
                {
                    AdminLastOnline.Text = admin.LastOnline.ToString();
                }

            }
        }
        private void FindByLogin_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.Login;
            TopMenuItem.Header = "Поиск по логину";
        }

    }
}
