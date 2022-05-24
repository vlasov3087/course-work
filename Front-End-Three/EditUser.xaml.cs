using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        string fileName;
        int counter = 0;
        ParamToFindUser choosenParam;
        bool isEmpty = true;
        List<DatabaseEntities.Client> clients;
        DatabaseEntities.Client clientBuffer;
        private IAdminAccess module;
        public EditUser(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            choosenParam = ParamToFindUser.Login;
            this.module = module;
            clients = module.GetAllClients();
            InitializeComponent();
            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(clients[0]);
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Show(DatabaseEntities.Client client)
        {
            if (client == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                UserImage.Source = App.ConvertToBitmapImage(client.Photo);
                UserLogin.Text = client.Login;
                UserStatus.Text = client.UserStatus.ToString();
                if (client.IsOnline)
                {
                    UserLastOnline.Text = "В сети";
                }
                else
                {
                    UserLastOnline.Text = client.LastOnline.ToString();
                }

            }
        }
        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in clients)
            {
                module.ModifyClient(item);
            }
        }

        private void UserImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fileName = op.FileName;
                UserImage.Source = new BitmapImage(new Uri(fileName));
            }
        }
        private void NewClient(DatabaseEntities.Client client)
        {
            if (client == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                client.Photo = new Bitmap(fileName);
                client.Login = UserLogin.Text;
            }
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            NewClient(clients[counter]);
        }

        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            clients.Clear();
            switch (choosenParam)
            {
                case ParamToFindUser.Login:
                    {
                        clientBuffer = module.FindClientByLogin(LoginInput.Text);
                        clients.Add(clientBuffer);
                        break;
                    }
                case ParamToFindUser.None:
                    {
                        clients = module.GetAllClients();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }

            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                Show(clients[0]);
            }
        }

        private void FindByLogin_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.Login;
            TopMenuItem.Header = "Поиск по логину";
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(clients[0]);
                }
                else
                {
                    counter--;
                    Show(clients[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (clients.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if(clients.Count == 1)
            {
                Show(clients[counter]);
            }
            else
            {
                if (counter + 1 == clients.Count)
                {
                    Show(clients[counter]);
                }
                else
                {
                    counter++;
                    Show(clients[counter]);
                }
            }
        }

        private void DataInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                UserLogin.Text = "";
                isEmpty = false;
            }
        }
    }
}
