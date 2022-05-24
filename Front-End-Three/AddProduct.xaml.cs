using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        string fileName;
        bool isEmpty = true, isEmptyTwo = true, isEmptyThree = true;
        private IAdminAccess module;
        public AddProduct(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            this.module = module;
            InitializeComponent();
        }
        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fileName = op.FileName;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {           
            decimal CostValue;
            try
            {
                CostValue = decimal.Parse(Cost.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            var answer = module.CreateProduct(new DatabaseEntities.Product()
            {
                Name = Name.Text,
                Cost = CostValue,
                Ingridients = Ingridients.Text,
                Photo = new System.Drawing.Bitmap(fileName)
            });
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
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Name_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                Name.Text = "";
                isEmpty = false;
            }
            if (Name.Text == "Введите имя")
            {
                Name.Text = "";
            }
            if (Ingridients.Text == "")
            {
                Ingridients.Text = "Введите ингредиенты";
            }
            if (Cost.Text == "")
            {
                Cost.Text = "Введите цену";
            }
        }
        private void Ingridients_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyTwo)
            {
                Ingridients.Text = "";
                isEmptyTwo = false;
            }
            if (Ingridients.Text == "Введите ингредиенты")
            {
                Ingridients.Text = "";
            }
            if (Name.Text == "")
            {
                Name.Text = "Введите название";
            }
            if (Cost.Text == "")
            {
                Cost.Text = "Введите цену";
            }
        }

        private void Cost_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyThree)
            {
                Cost.Text = "";
                isEmptyThree = false;
            }
            if (Cost.Text == "Введите цену")
            {
                Cost.Text = "";
            }
            if (Name.Text == "")
            {
                Name.Text = "Введите название";
            }
            if (Ingridients.Text == "")
            {
                Ingridients.Text = "Введите ингредиенты";
            }
        }
    }
}
