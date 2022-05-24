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
    /// Логика взаимодействия для EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        string fileName;
        int counter = 0;
        ParamToFindProduct choosenParam;
        bool isEmpty = true;
        private IAdminAccess module;
        List<DatabaseEntities.Product> products;
        public EditProduct(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            choosenParam = ParamToFindProduct.Name;
            this.module = module;
            products = module.GetAllProducts();
            InitializeComponent();
            if (products == null || products.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(products[0]);
        }
        private void SomeInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                SomeInput.Text = "";
                isEmpty = false;
            }
        }

        private void Show(DatabaseEntities.Product product)
        {
            if (product == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                EntityPhoto.Source = App.ConvertToBitmapImage(product.Photo);
                ProductCost.Text = product.Cost.ToString();
                ProductIngridients.Text = product.Ingridients;
                ProductName.Text = product.Name;
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindProduct.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(products[0]);
                }
                else
                {
                    counter--;
                    Show(products[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if (products.Count == 1)
            {
                Show(products[counter]);
            }
            else
            {
                if (counter + 1 == products.Count)
                {
                    Show(products[counter]);
                }
                else
                {
                    counter++;
                    Show(products[counter]);
                }
            }
        }

        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            products.Clear();
            switch (choosenParam)
            {
                case ParamToFindProduct.Name:
                    {
                        products = module.GetAllProducts();
                        products = products.FindAll(c => (c.Name == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFindProduct.Cost:
                    {
                        products = module.GetAllProducts();
                        products = products.FindAll(c => (c.Cost == decimal.Parse((SomeInput.Text)))).ToList();
                        break;
                    }
                case ParamToFindProduct.Ingridients:
                    {
                        products = module.GetAllProducts();
                        products = products.FindAll(c => (c.Ingridients == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFindProduct.None:
                    {
                        products = module.GetAllProducts();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }
        }

        private void FindByName_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindProduct.Name;
            TopMenuItem.Header = "Поиск по имени";
        }

        private void FindByCost_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindProduct.Cost;
            TopMenuItem.Header = "Поиск по цене";
        }

        private void FindByIgridients_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindProduct.Ingridients;
            TopMenuItem.Header = "Поиск по игредиентам";
        }
        private void NewProduct(DatabaseEntities.Product product)
        {

            decimal CostValue;
            try
            {
                CostValue = decimal.Parse(ProductCost.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            if (product == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                product.Name = ProductName.Text;
                product.Cost = CostValue;
                product.Ingridients = ProductIngridients.Text;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            decimal CostValue;
            try
            {
                CostValue = decimal.Parse(ProductCost.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            if (ProductCost.Text == "" || ProductIngridients.Text == "" || ProductName.Text == "")
            {
                MessageBox.Show("Ошибка!");
            }
            else
                NewProduct(products[counter]);
            MessageBox.Show("Успешно!");
        }

        private void SaveObject_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in products)
            {
                module.ModifyProduct(item);
            }
            MessageBox.Show("Редактирование успешно!");
        }

        private void EntityPhoto_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                fileName = op.FileName;
                EntityPhoto.Source = new BitmapImage(new Uri(fileName));
            }
        }
    }
}
