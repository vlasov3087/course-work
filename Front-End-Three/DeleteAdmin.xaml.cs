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

namespace Front_End_Three
{
    /// <summary>
    /// Логика взаимодействия для DeleteAdmin.xaml
    /// </summary>
    public partial class DeleteAdmin : Window
    {
        bool isEmpty = true;
        public DeleteAdmin()
        {
            InitializeComponent();
        }

        private void LoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                LoginInput.Text = "";
                isEmpty = false;
            }
        }

        private void FindAdmin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
