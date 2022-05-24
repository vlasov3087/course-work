using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainContentWindow.xaml
    /// </summary>
    public partial class MainContentWindow : Window
    {
        private IAdminAccess module;
        public MainContentWindow(IAdminAccess module)
        {
            this.module = module;
            InitializeComponent();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            module.PreviousRoom();
            MainWindow mainWindow = new MainWindow(module as ClientConnectionModule);
            mainWindow.Show();
            this.Close();
        }

        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            FindUser findUser = new FindUser(module);
            findUser.ShowDialog();
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(module);
            addUser.ShowDialog();
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            EditUser editUser = new EditUser(module);
            editUser.ShowDialog();
        }

        private void BlockUser_Click(object sender, RoutedEventArgs e)
        {
            BlockUser blockUser = new BlockUser(module);
            blockUser.ShowDialog();
        }

        private void UnblockUser_Click(object sender, RoutedEventArgs e)
        {
            UnblockUser blockUser = new UnblockUser(module);
            blockUser.ShowDialog();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser deleteUser = new DeleteUser(module);
            deleteUser.ShowDialog();
        }

        private void FindBySomething_Click(object sender, RoutedEventArgs e)
        {
            FindBySomething findBySomething = new FindBySomething(module);
            findBySomething.ShowDialog();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(module);
            add.ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit(module);
            edit.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete(module);
            delete.ShowDialog();
        }

        private void AddExpert_Click(object sender, RoutedEventArgs e)
        {
            AddExpert addExpert = new AddExpert(module);
            addExpert.ShowDialog();
        }

        private void BlockExpert_Click(object sender, RoutedEventArgs e)
        {
            BlockExpert blockExpert = new BlockExpert(module);
            blockExpert.ShowDialog();
        }

        private void UnblockExpert_Click(object sender, RoutedEventArgs e)
        {
            UnblockExpert unblockExpert = new UnblockExpert(module);
            unblockExpert.ShowDialog();
        }

        private void DeleteExpert_Click(object sender, RoutedEventArgs e)
        {
            DeleteExpert deleteExpert = new DeleteExpert(module);
            deleteExpert.ShowDialog();
        }

        private void AddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AddAdmin addAdmin = new AddAdmin(module);
            addAdmin.ShowDialog();
        }

        private void FindExpert_Click(object sender, RoutedEventArgs e)
        {
            FindExpert findExpert = new FindExpert(module);
            findExpert.ShowDialog();
        }

        private void FindAdmin_Click(object sender, RoutedEventArgs e)
        {
            FindAdmin findAdmin = new FindAdmin(module);
            findAdmin.ShowDialog();
        }

        private void CreateReport_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("reportFile.txt", false))
            {
                streamWriter.Write(module.GetReport());
                MessageBox.Show("Отчёт создан!");
            }   
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Sort sort = new Sort(module);
            sort.ShowDialog();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Filtration filtration = new Filtration(module);
            filtration.ShowDialog();
        }

        private void FindProduct_Click(object sender, RoutedEventArgs e)
        {
            FindProduct findProduct= new FindProduct(module);
            findProduct.ShowDialog();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProduct addProduct = new AddProduct(module);
            addProduct.ShowDialog();
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            EditProduct editProduct = new EditProduct(module);
            editProduct.ShowDialog();
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            DeleteProduct deleteProduct = new DeleteProduct(module);
            deleteProduct.ShowDialog();
        }
    }
}
