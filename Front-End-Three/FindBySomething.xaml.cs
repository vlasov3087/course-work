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
    /// Логика взаимодействия для FindBySomething.xaml
    /// </summary>
    enum ParamToFind
    {
        Name,
        Status,
        Experience,
        None
    }
    public partial class FindBySomething : Window
    {
        int counter = 0;
        ParamToFind choosenParam;
        bool isEmpty = true;
        private IDataViewAccess module;
        List<DatabaseEntities.Employee> emplyees;
        public FindBySomething(IDataViewAccess module)
        {
            choosenParam = ParamToFind.Name;
            this.module = module;
            emplyees = module.GetAllEmployees();
            InitializeComponent();
            if (emplyees == null || emplyees.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(emplyees[0]);
        }

        private void SomeInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                SomeInput.Text = "";
                isEmpty = false;
            }
        }

        private void Show(DatabaseEntities.Employee employee)
        {
            if (employee == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                EntityPhoto.Source = App.ConvertToBitmapImage(employee.Photo);
                EmployeeExperience.Text = employee.Experience.ToString();
                EmployeeName.Text = employee.FullName;
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (emplyees.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(emplyees[0]);
                }
                else
                {
                    counter--;
                    Show(emplyees[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (emplyees.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if (emplyees.Count == 1)
            {
                Show(emplyees[counter]);
            }
            else
            {
                if (counter + 1 == emplyees.Count)
                {
                    Show(emplyees[counter]);
                }
                else
                {
                    counter++;
                    Show(emplyees[counter]);
                }
            }
        }

        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            emplyees.Clear();
            switch (choosenParam)
            {
                case ParamToFind.Name:
                    {
                        emplyees = module.GetAllEmployees();
                        emplyees = emplyees.FindAll(c => (c.FullName == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFind.Status:
                    {
                        emplyees = module.GetAllEmployees();
                        emplyees = emplyees.FindAll(c => (c.Position.ToString() == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFind.Experience:
                    {
                        emplyees = module.GetAllEmployees();
                        emplyees = emplyees.FindAll(c => (c.Experience == int.Parse(SomeInput.Text))).ToList();
                        break;
                    }
                case ParamToFind.None:
                    {
                        emplyees = module.GetAllEmployees();
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
            choosenParam = ParamToFind.Name;
            TopMenuItem.Header = "Поиск по имени";
        }

        private void FindByStatus_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.Status;
            TopMenuItem.Header = "Поиск по должности";
        }

        private void FindByExperience_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFind.Experience;
            TopMenuItem.Header = "Поиск по опыту";
        }
    }
}
