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
    /// Логика взаимодействия для findProduct.xaml
    /// </summary>
    enum ParamToFindProduct
    {
        Name,
        Cost,
        Ingridients,
        None
    }
    public partial class FindProduct : Window
    {

        int counter = 0;
        ParamToFindProduct choosenParam;
        bool isEmpty = true;
        private IDataViewAccess module;
        List<DatabaseEntities.Product> products;
        public FindProduct(IDataViewAccess module)
        {
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
    }
}
