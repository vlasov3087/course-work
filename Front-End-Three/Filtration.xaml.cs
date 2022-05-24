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
    /// Логика взаимодействия для Filtration.xaml
    /// </summary>
    enum ParamToFilter
    {
        Experience
    }
    public partial class Filtration : Window
    {
        int counter = 0;
        ParamToFilter choosenParam;
        private IDataViewAccess module;
        List<DatabaseEntities.Employee> employees;
        public Filtration(IDataViewAccess module)
        {
            choosenParam = ParamToFilter.Experience;
            this.module = module;
            employees = module.GetAllEmployees();
            InitializeComponent();
            if (employees == null || employees.Count == 0 )
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(employees[0]);
        }


        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(FirstValue.Text);
                value2 = double.Parse(SecondValue.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка ввода!");
                return;
            }
            switch (choosenParam)
            {
                case ParamToFilter.Experience:
                    {
                        employees = employees.Where(c => (c.Experience >= value1 && c.Experience <= value2)).ToList();
                        break;
                    }
                default:
                    break;
            }
          
            counter = 0;
            if (employees.Count == 0)
            {
                MessageBox.Show("Нет данных!");
                FirstValue.Text = "";
                SecondValue.Text = "";
                employees = module.GetAllEmployees();
            }
            if (employees.Count == 0)
                MessageBox.Show("Ошибка!");
            else
                Show(employees[counter]);

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


        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (employees.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(employees[0]);
                }
                else
                {
                    counter--;
                    Show(employees[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (employees.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if (employees.Count == 1)
            {
                Show(employees[counter]);
            }
            else
            {
                if (counter + 1 == employees.Count)
                {
                    Show(employees[counter]);
                }
                else
                {
                    counter++;
                    Show(employees[counter]);
                }
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FilterByExperience_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFilter.Experience;
            TopMenuItem.Header = "Фильтрация по опыту";
        }
    }
}
