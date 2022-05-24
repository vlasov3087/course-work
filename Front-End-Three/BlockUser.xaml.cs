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
    /// Логика взаимодействия для BlockUser.xaml
    /// </summary>
    public partial class BlockUser : Window
    {
        bool isEmpty = true;
        private IAdminAccess module;
        public BlockUser(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                LoginInput.Text = "";
                isEmpty = false;
            }
        }

        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            var answer = module.BanClientWith(LoginInput.Text);
            switch (answer)
            {
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Successfully:
                    {
                        MessageBox.Show("Успешно!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.Error:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                case ClassLibraryForTCPConnectionAPI_C_sharp_.AnswerFromServer.UnknownCommand:
                    {
                        MessageBox.Show("Ошибка!");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
