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
        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Display_Result.Text = MathParser.EvalExpression(Display.Text.ToCharArray()).ToString();
            int value = int.Parse(Display_Result.Text);
            Display_Binary.Text = Convert.ToString(value, 2);

            Display_Postorder.Text = InfixToPostfix(Display.Text);

            string revString = ReverseAndCleanString(Display.Text);
            string postFixRevStr = InFixToPostFix(revString);
            string preFixStr = ReverseAndCleanString(postFixRevStr);
            Display_Preorder.Text = preFixStr;
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

        //===================================================================================//
        public static void InFixToPreFix(string infixExpression)
        {

            if (infixExpression == null || infixExpression.Length == 0)
                return;

            Console.WriteLine("In-Fix Expression = {0}", infixExpression);

            string revString = ReverseAndCleanString(infixExpression);
            Console.WriteLine("Reversed In-Fix Expression = {0}", revString);
            string postFixRevStr = InFixToPostFix(revString);
            Console.WriteLine("Post-Fix Expression = {0}", postFixRevStr);
            string preFixStr = ReverseAndCleanString(postFixRevStr);

            Console.WriteLine("Pre-Fix Expression = {0}", preFixStr);
            Console.WriteLine("");
        }
        //Time Complexity: O(n) Space Complexity: O(n)
        public static string InFixToPostFix(string infixExpression)
        {
            if (infixExpression == null || infixExpression.Length == 0)
                return string.Empty;

            StringBuilder strBuilder = new StringBuilder();
            Stack<char> s = new Stack<char>();

            for (int i = 0; i <= infixExpression.Length - 1; i++)
            {
                if (infixExpression[i] >= '0' && infixExpression[i] <= '9')
                {
                    strBuilder.Append(infixExpression[i]);
                }
                else if (infixExpression[i] == '(')
                {
                    s.Push(infixExpression[i]);
                }
                else if (infixExpression[i] == ')')
                {
                    while (s.Count > 0 && s.Peek() != '(')
                    {
                        strBuilder.Append(s.Pop());
                    }
                    s.Pop();
                }
                else if (infixExpression[i] == '+' || infixExpression[i] == '-'
                         || infixExpression[i] == '/' || infixExpression[i] == '*')
                {

                    while (s.Count > 0 && HasSamePrecedent(infixExpression[i], s.Peek()) == true)
                    {
                        strBuilder.Append(s.Pop());
                    }

                    while (s.Count > 0 && IncomingSymbol_IsLowPrecedent(infixExpression[i], s.Peek()) == true)
                    {
                        strBuilder.Append(s.Pop());
                    }

                    s.Push(infixExpression[i]);
                }
            }

            while (s.Count != 0)
            {
                strBuilder.Append(s.Pop());
            }

            return strBuilder.ToString();
        }

        // opA = Incoming Symbol , opB = Top item on stack
        public static bool HasSamePrecedent(char opA, char opB)
        {
            if ((opA == '+' || opA == '-') && (opB == '+' || opB == '-'))
            {
                return true;
            }
            else if ((opA == '*' || opA == '/') && (opB == '*' || opB == '/'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // opA = Incoming Symbol , opB = Top item on stack
        public static bool IncomingSymbol_IsLowPrecedent(char opA, char opB)
        {
            if ((opA == '+' || opA == '-') && (opB == '*' || opB == '/'))
            {
                return true;
            }
            else
                return false;
        }
    
        public static string ReverseAndCleanString(string str)
        {
            char[] inputarray = str.ToCharArray();
            Array.Reverse(inputarray);
            for (int i = 0; i <= inputarray.Length - 1; i++)
            {
                if (inputarray[i] == '(')
                {
                    inputarray[i] = ')';
                }
                else if (inputarray[i] == ')')
                {
                    inputarray[i] = '(';
                }
                else
                {
                    continue;
                }
            }
            return new string(inputarray);
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
