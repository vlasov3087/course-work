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
    /// Логика взаимодействия для ExpertMethod.xaml
    /// </summary>
    public partial class ExpertMethod : Window
    {
        private IExpertAccess module;

        public ExpertMethod(IExpertAccess module)
        {
            this.module = module;
            InitializeComponent();

            Z1.Text = "";
            Z2.Text = "";
            Z3.Text = "";
            Z4.Text = "";
            Z5.Text = "";

            R1.Text = "";
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            int z1, z2, z3, z4, z5;

            z1 = int.Parse(Z1.Text);
            z2 = int.Parse(Z2.Text);
            z3 = int.Parse(Z3.Text);
            z4 = int.Parse(Z4.Text);
            z5 = int.Parse(Z5.Text);

            if (R1.Text == "0" || (z1 + z2 + z3 + z4 + z5) != 100)
            {
                MessageBox.Show("Необходимо заполнить рейтинг!\nСумма полей оценки должно быть рано 100!");
            }
            else
            {

                int rz1, rz2, rz3, rz4, rz5;

                rz1 = Int32.Parse(Z1.Text);
                rz2 = Int32.Parse(Z2.Text);
                rz3 = Int32.Parse(Z3.Text);
                rz4 = Int32.Parse(Z4.Text);
                rz5 = Int32.Parse(Z5.Text);

                int rt1;

                rt1 = Int32.Parse(R1.Text);

                double s1, s2, s3, s4, s5;

                s1 = rt1 * rz1;
                s2 = rt1 * rz2;
                s3 = rt1 * rz3;
                s4 = rt1 * rz4;
                s5 = rt1 * rz5;

                double sum = s1 + s2 + s3 + s4 + s5;

                double w1, w2, w3, w4, w5;

                w1 = Math.Round(s1 / sum, 2);
                w2 = Math.Round(s2 / sum, 2);
                w3 = Math.Round(s3 / sum, 2);
                w4 = Math.Round(s4 / sum, 2);
                w5 = Math.Round(s5 / sum, 2);

                Rez_Z1.Text = w1.ToString();
                Rez_Z2.Text = w2.ToString();
                Rez_Z3.Text = w3.ToString();
                Rez_Z4.Text = w4.ToString();
                Rez_Z5.Text = w5.ToString();

                var map = new Dictionary<string, double>();
                map.Add("1", w1);
                map.Add("2", w2);
                map.Add("3", w3);
                map.Add("4", w4);
                map.Add("5", w5);

                MessageBox.Show("Лучший вариант:  " + map.OrderByDescending(key => key.Value).First().Key + "  с коэффициентом  " + map.OrderByDescending(key => key.Value).First().Value.ToString());            
            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {

            Z1.Text = "";
            Z2.Text = "";
            Z3.Text = "";
            Z4.Text = "";
            Z5.Text = "";

            R1.Text = "";

            Rez_Z1.Text = "";
            Rez_Z2.Text = "";
            Rez_Z3.Text = "";
            Rez_Z4.Text = "";
            Rez_Z5.Text = "";
        }

        private void Button_Out(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
