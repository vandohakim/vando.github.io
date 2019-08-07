using System;
using System.Collections;
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
using MySql.Data.MySqlClient;
using System.Data;

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

        MySqlConnection koneksi = new MySqlConnection("server=localhost;port=3306;database=kalkulatorcsharp;uid=root;password=;SslMode=none");

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
            input = Display.Text;
            this.Display.Text = "";
            this.Display.Text += input;
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
        static Boolean isOperator(char x)
        {

            switch (x)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    return true;
            }
            return false;
        }

        // Convert postfix to Prefix expression 
        static String postToPre(String post_exp)
        {
            Stack s = new Stack();

            // length of expression 
            int length = post_exp.Length;

            // reading from right to left 
            for (int i = 0; i < length; i++)
            {

                // check if symbol is operator 
                if (isOperator(post_exp[i]))
                {

                    // Pop two operands from stack 
                    String op1 = (String)s.Peek();
                    s.Pop();
                    String op2 = (String)s.Peek();
                    s.Pop();

                    // concat the operands and operator 
                    String temp = post_exp[i] + op2 + op1;

                    // Push String temp back to stack 
                    s.Push(temp);
                }

                // if symbol is an operand 
                else
                {

                    // Push the operand to the stack 
                    s.Push(post_exp[i] + "");
                }
            }

            // stack[0] contains the Prefix expression 
            return (String)s.Peek();
        }
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Display_Result.Text = MathParser.EvalExpression(Display.Text.ToCharArray()).ToString();
            int value = int.Parse(Display_Result.Text);
            Display_Binary.Text = Convert.ToString(value, 2);

            Display_Postorder.Text = InfixToPostfix(Display.Text);

            Display_Preorder.Text = postToPre(Display_Postorder.Text);
        }

        private void Datalist_Click(object sender, RoutedEventArgs e)
        {
            Windowkedua W2 = new Windowkedua();
            W2.Show();
            this.Hide();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand check_display = new MySqlCommand("select * FROM csharphw2 WHERE display = '" + Display.Text + "'", koneksi);
            MySqlDataAdapter da = new MySqlDataAdapter(check_display);
            DataSet ds1 = new DataSet();
            da.Fill(ds1);
            int i = ds1.Tables[0].Rows.Count;

            if (i > 0)
            {
                //Username exist
                MessageBox.Show("Data already exist!");
            }
            else
            {
                //Username doesn't exist.
                koneksi.Open();
                MySqlCommand cmd;
                cmd = koneksi.CreateCommand();
                cmd.CommandText = "insert into csharphw2 (display,postorder,preorder,decimalresult,binaryresult) values (@display,@postorder,@preorder,@decimalresult,@binaryresult)";
                cmd.Parameters.AddWithValue("@display", Display.Text);
                cmd.Parameters.AddWithValue("@postorder", Display_Postorder.Text);
                cmd.Parameters.AddWithValue("@preorder", Display_Preorder.Text);
                cmd.Parameters.AddWithValue("@decimalresult", Display_Result.Text);
                cmd.Parameters.AddWithValue("@binaryresult", Display_Binary.Text);
                MessageBox.Show("Success add data");
                cmd.ExecuteNonQuery();
                koneksi.Close();
            }
        }
        //===================================================================================//
        public static string InfixToPostfix(string exp)
        {
            // initializing empty String for result
            String result = String.Empty;

            // initializing empty stack
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; ++i)
            {
                char c = exp[i];

                // If the scanned character is an operand, add it to output.
                if (Char.IsLetterOrDigit(c))
                    result += c;

                // If the scanned character is an '(', push it to the stack.
                else if (c == '(')
                    stack.Push(c);

                //  If the scanned character is an ')', pop and output from the stack 
                // until an '(' is encountered.
                else if (c == ')')
                {
                    while (stack.Count != 0 && stack.Peek() != '(')
                        result += stack.Pop();

                    if (stack.Count != 0 && stack.Peek() != '(')
                        return "Invalid Expression"; // invalid expression                
                    else
                        stack.Pop();
                }
                else // an operator is encountered
                {
                    while (stack.Count != 0 && Prec(c) <= Prec(stack.Peek()))
                        result += stack.Pop();
                    stack.Push(c);
                }

            }

            // pop all the operators from the stack
            while (stack.Count != 0)
                result += stack.Pop();

            return result;
        }

        // A utility function to return precedence of a given operator
        // Higher returned value means higher precedence
        public static int Prec(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
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
