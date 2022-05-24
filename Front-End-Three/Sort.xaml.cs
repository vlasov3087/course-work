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
    /// Логика взаимодействия для Sort.xaml
    /// </summary>
    enum ParamToSort
    {
        Name,
        Position,
        Experience
    }
    public partial class Sort : Window
    {
        int counter = 0;
        ParamToSort choosenParam;
        private IDataViewAccess module;
        List<DatabaseEntities.Employee> employees;
        public Sort(IDataViewAccess module)
        {
            choosenParam = ParamToSort.Name;
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

        private void SortByName_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Name;
            TopMenuItem.Header = "Сортировка по названию";
            employees = employees.OrderBy(c => c.FullName).ToList();
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

        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            if(employees.Count == 0)
            {
                MessageBox.Show("Ошибка!");
            }
            else
            {
                Show(employees[0]);
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SortByPosiiton_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Position;
            TopMenuItem.Header = "Сортировка по должности";
            employees = employees.OrderBy(c => c.Position).ToList();
        }

        private void SortByExperience_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToSort.Experience;
            TopMenuItem.Header = "Сортировка по опыту";
            employees = employees.OrderBy(c => c.Experience).ToList();
        }
    }
}
