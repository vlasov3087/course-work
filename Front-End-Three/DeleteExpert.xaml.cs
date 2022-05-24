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
    /// Логика взаимодействия для DeleteExpert.xaml
    /// </summary>
    public partial class DeleteExpert : Window
    {
        int counter = 0;
        ParamToFindUser choosenParam;
        bool isEmpty = true;
        private IAdminAccess module;
        List<DatabaseEntities.Expert> experts;
        DatabaseEntities.Expert expertBuffer;
        public DeleteExpert(IAdminAccess module)
        {
            choosenParam = ParamToFindUser.Login;
            this.module = module;
            experts = module.GetAllExperts();
            InitializeComponent();
            if (experts == null || experts.Count == 0)
            {
                MessageBox.Show("Нет данных!");
            }
            else
                Show(experts[0]);
        }

        private void Show(DatabaseEntities.Expert expert)
        {
            if (expert == null)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                ExpertImage.Source = App.ConvertToBitmapImage(expert.Photo);
                ExpertLogin.Text = expert.Login;
                ExpertStatus.Text = expert.UserStatus.ToString();
                if (expert.IsOnline)
                {
                    ExpertLastOnline.Text = "В сети";
                }
                else
                {
                    ExpertLastOnline.Text = expert.LastOnline.ToString();
                }

            }
        }
        private void FindExpert_Click(object sender, RoutedEventArgs e)
        {
            experts.Clear();
            switch (choosenParam)
            {
                case ParamToFindUser.Login:
                    {
                        expertBuffer = module.FindExpertByLogin(ExpertLoginInput.Text);
                        experts.Add(expertBuffer);
                        break;
                    }
                case ParamToFindUser.None:
                    {
                        experts = module.GetAllExperts();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Повторите попытку!");
                        break;
                    }
            }

            if (experts.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                Show(experts[0]);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ExpertLoginInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isEmpty)
            {
                ExpertLoginInput.Text = "";
                isEmpty = false;
            }
        }

        private void FindByLogin_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.Login;
            TopMenuItem.Header = "Поиск по логину";
        }

        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            choosenParam = ParamToFindUser.None;
            TopMenuItem.Header = "Показать всё";
        }

        private void LeftArrow_Click(object sender, RoutedEventArgs e)
        {
            if (experts.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else
            {
                if (counter == 0)
                {
                    Show(experts[0]);
                }
                else
                {
                    counter--;
                    Show(experts[counter]);
                }
            }
        }

        private void RightArrow_Click(object sender, RoutedEventArgs e)
        {
            if (experts.Count == 0)
            {
                MessageBox.Show("Не найдено!");
            }
            else if(experts.Count == 1)
            {
                Show(experts[counter]);
            }
            else
            {
                if (counter + 1 == experts.Count)
                {
                    Show(experts[counter]);
                }
                else
                {
                    counter++;
                    Show(experts[counter]);
                }
            }
        }

        private void DeleteExpert_Click(object sender, RoutedEventArgs e)
        {
            module.DeleteExpertWith(experts[counter].Login);
        }
    }
}

