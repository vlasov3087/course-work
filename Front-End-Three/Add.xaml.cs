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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        string fileName;
        bool isEmpty = true, isEmptyTwo = true, isEmptyThree = true;
        private IAdminAccess module;
        public Add(IAdminAccess module)
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
            DatabaseEntities.Position PositionValue;
            switch (Position.Text)
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
                ExperienceValue = int.Parse(Experience.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный ввод!");
                return;
            }
            var answer = module.CreateEmployee(new DatabaseEntities.Employee()
            {
                FullName = Name.Text,
                Experience = ExperienceValue,
                Position = PositionValue,
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

        private void Position_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyThree)
            {
                Position.Text = "";
                isEmptyThree = false;
            }
            if (Position.Text == "Введите должность")
            {
                Position.Text = "";
            }
            if (Experience.Text == "")
            {
                Experience.Text = "Введите опыт";
            }
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
            }
        }

        private void Experience_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmptyTwo)
            {
                Experience.Text = "";
                isEmptyTwo = false;
            }
            if (Experience.Text == "Введите опыт")
            {
                Experience.Text = "";
            }
            if (Position.Text == "")
            {
                Position.Text = "Введите должность";
            }
            if (Name.Text == "")
            {
                Name.Text = "Введите имя";
            }
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
            if (Position.Text == "")
            {
                Position.Text = "Введите должность";
            }
            if (Experience.Text == "")
            {
                Experience.Text = "Введите опыт";
            }
        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
