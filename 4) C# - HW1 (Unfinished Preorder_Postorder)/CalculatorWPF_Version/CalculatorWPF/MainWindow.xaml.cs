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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "1";
            this.Display.Text += input;
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "2";
            this.Display.Text += input;
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "3";
            this.Display.Text += input;
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "4";
            this.Display.Text += input;
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "5";
            this.Display.Text += input;
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "6";
            this.Display.Text += input;
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "7";
            this.Display.Text += input;
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "8";
            this.Display.Text += input;
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "9";
            this.Display.Text += input;
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "0";
            this.Display.Text += input;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "*";
            this.Display.Text += input;
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "/";
            this.Display.Text += input;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "+";
            this.Display.Text += input;
        }
        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            input += "-";
            this.Display.Text += input;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Display.Text = "";
            this.input = string.Empty;
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Display_Result.Text = MathParser.EvalExpression(Display.Text.ToCharArray()).ToString();
            int value = int.Parse(Display_Result.Text);
            Display_Binary.Text = Convert.ToString(value, 2);
        }
    }
    class MathParser
    {

        public static double EvalExpression(char[] expr)
        {
            return parseSummands(expr, 0);
        }

        private static double parseSummands(char[] expr, int index)
        {
            double x = parseFactors(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '+' && op != '-')
                    return x;
                index++;
                double y = parseFactors(expr, ref index);
                if (op == '+')
                    x += y;
                else
                    x -= y;
            }
        }

        private static double parseFactors(char[] expr, ref int index)
        {
            double x = GetDouble(expr, ref index);
            while (true)
            {
                char op = expr[index];
                if (op != '/' && op != '*')
                    return x;
                index++;
                double y = GetDouble(expr, ref index);
                if (op == '/')
                    x /= y;
                else
                    x *= y;
            }
        }

        private static double GetDouble(char[] expr, ref int index)
        {
            string dbl = "";
            while (((int)expr[index] >= 48 && (int)expr[index] <= 57) || expr[index] == 46)
            {
                dbl = dbl + expr[index].ToString();
                index++;
                if (index == expr.Length)
                {
                    index--;
                    break;
                }
            }
            return double.Parse(dbl);
        }
    }

}
