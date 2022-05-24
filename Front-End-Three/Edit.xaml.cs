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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        string fileName;
        int counter = 0;
        ParamToFind choosenParam;
        bool isEmpty = true;
        private IAdminAccess module;
        List<DatabaseEntities.Employee> employees;
        public Edit(IAdminAccess module)
        {
            fileName = ConfigurationManager.AppSettings.Get("defaultPhotoPath");
            choosenParam = ParamToFind.Name;
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

        private void FindSome_Click(object sender, RoutedEventArgs e)
        {
            employees.Clear();
            switch (choosenParam)
            {
                case ParamToFind.Name:
                    {
                        employees = module.GetAllEmployees();
                        employees = employees.FindAll(c => (c.FullName == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFind.Status:
                    {
                        employees = module.GetAllEmployees();
                        employees = employees.FindAll(c => (c.Position.ToString() == SomeInput.Text)).ToList();
                        break;
                    }
                case ParamToFind.Experience:
                    {
                        employees = module.GetAllEmployees();
                        employees = employees.FindAll(c => (c.Experience == int.Parse(SomeInput.Text))).ToList();
                        break;
                    }
                case ParamToFind.None:
                    {
                        employees = module.GetAllEmployees();
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
        private void NewEmployee(DatabaseEntities.Employee employee)
        {

            DatabaseEntities.Position PositionValue;
            switch (EmployeeStatus.Text)
            {
                case "Уборщик":
                    {
                        PositionValue = DatabaseEntities.Position.Cleaner;
                        break;
                    }
                case "Кондитер":
                    {
                        PositionValue = DatabaseEntities.Position.Baker;
                        break;
                    }
                case "Администратор":
                    {
                        PositionValue = DatabaseEntities.Position.Administrator;
                        break;
                    }
                case "Менеджер":
                    {
                        PositionValue = DatabaseEntities.Position.Manager;
                        break;
                    }
                case "Менеджер по продажам":
                    {
                        PositionValue = DatabaseEntities.Position.SalesManager;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Введите Уборщик, Администратор, Кондитер или Менеджер по продажам!");
                        return;
                    }
            }
            int ExperienceValue;
            try
            {
                ExperienceValue = int.Parse(EmployeeExperience.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            if (employee == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                employee.FullName = EmployeeName.Text;
                employee.Position = PositionValue;
                employee.Experience = ExperienceValue;
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            DatabaseEntities.Position PositionValue;
            switch (EmployeeStatus.Text)
            {
                case "Уборщик":
                    {
                        PositionValue = DatabaseEntities.Position.Cleaner;
                        break;
                    }
                case "Кондитер":
                    {
                        PositionValue = DatabaseEntities.Position.Baker;
                        break;
                    }
                case "Администратор":
                    {
                        PositionValue = DatabaseEntities.Position.Administrator;
                        break;
                    }
                case "Менеджер":
                    {
                        PositionValue = DatabaseEntities.Position.Manager;
                        break;
                    }
                case "Менеджер по продажам":
                    {
                        PositionValue = DatabaseEntities.Position.SalesManager;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Введите Уборщик, Администратор, Кондитер или Менеджер по продажам!");
                        return;
                    }
            }
            int ExperienceValue;
            try
            {
                ExperienceValue = int.Parse(EmployeeExperience.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            if (EmployeeExperience.Text == "" || EmployeeName.Text == "" || EmployeeStatus.Text == "")
            {
                MessageBox.Show("Ошибка!");
            }
            else
                NewEmployee(employees[counter]);
            MessageBox.Show("Успешно!");
        }

        private void SaveObject_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in employees)
            {
                module.ModifyEmployee(item);
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
