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

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string First;
        private string Second;
        private string Operand;
        private bool IsOperand;
        private bool FirstIsDot;
        private bool SecondIsDot;
        public MainWindow()
        {
            InitializeComponent();
            First = "";
            Second = "";
            Operand = "";
            IsOperand = false;
            ShowNumsButtons(true);
            ShowOperandsButtons(false);
            ShowResultButton(false);
            ShowDotButton(false);
        }


        //switch case делаем, где определяем все кнопки символами
        //Умножаем число на 10 и прибавляем то, что нажали
        // считать количество символов после запятой,
        // сделать добавление символа после запятой 
        private void Button_AddSimbol(object sender, RoutedEventArgs e)
        {
            string simbol;
            Button? simbolButton = (sender as Button);

            if (simbolButton != null && simbolButton.Content != null)
                simbol = simbolButton.Content.ToString();
            else simbol = "";

            if (!IsOperand)
                First = AddSimbol(First, simbol);
            else
                Second = AddSimbol(Second, simbol);

            ShowString("");

            if (First.Count() > 0)
                ShowOperandsButtons(true);

            if (Second.Count() > 0)
                ShowResultButton(true);

            if (IsOperand != true && FirstIsDot != true)
                ShowDotButton(true);
            if (IsOperand == true && SecondIsDot != true)
                ShowDotButton(true);

        }

        private void Button_AddOpperand(object sender, RoutedEventArgs e)
        {
            if (!IsOperand)
            {
                Button? operandButton = sender as Button;
                if (operandButton != null && operandButton.Content != null)
                {
                    IsOperand = true;
                    Operand = operandButton.Content.ToString();
                }
                else Operand = "";
                ShowString("");

                ShowOperandsButtons(false);
                ShowResultButton(false);
                ShowDotButton(false);
            }
        }

        private void Button_Reset(object sender, RoutedEventArgs e)
        {
            First = "";
            Second = "";
            IsOperand = false;
            Operand = "";
            FirstIsDot = false;
            SecondIsDot = false;
            ShowString("");
            ShowNumsButtons(true);
            ShowOperandsButtons(false);
            ShowResultButton(false);
            ShowDotButton(false);
        }

        private void Button_AddDot(object sender, RoutedEventArgs e)
        {
            if (!IsOperand)
                if (!FirstIsDot)
                {
                    First = First.Insert(First.Count(), ",");
                    ShowString("");

                    ShowOperandsButtons(false);
                    ShowDotButton(false);
                }
            if (IsOperand)
                if (!SecondIsDot)
                {
                    Second = Second.Insert(Second.Count(), ",");
                    ShowString("");

                    ShowOperandsButtons(false);
                    ShowDotButton(false);
                }
        }

        private void Button_Result(object sender, RoutedEventArgs e)
        {
            float f = float.Parse(First);
            float s = float.Parse(Second);
            float res;
            switch (Operand)
            {
                case "+":
                    res = f + s;
                    break;
                case "-":
                    res = f - s;
                    break;
                case "*":
                    res = f * s;
                    break;
                case "/":
                    res = f / s;
                    break;
                default:
                    res = 0;
                    break;
            }
            ShowString("=" + res.ToString());

            ShowNumsButtons(false);
            ShowOperandsButtons(false);
            ShowResultButton(false);
            ShowDotButton(false);
        }

        private void ShowString(string res)
        {
            ResultBox.Text = First + Operand + Second + res;
        }

        private string AddSimbol(string s, string? simbol)
        {
            if (simbol == null)
                return s;
            if (s == null)
                return simbol;
            s = s.Insert(s.Count(), simbol);
            return s;
        }
        private void ShowNumsButtons(bool b)
        {
            Button0.IsEnabled = b;
            Button1.IsEnabled = b;
            Button2.IsEnabled = b;
            Button3.IsEnabled = b;
            Button4.IsEnabled = b;
            Button5.IsEnabled = b;
            Button6.IsEnabled = b;
            Button7.IsEnabled = b;
            Button8.IsEnabled = b;
            Button9.IsEnabled = b;
            Button0.IsEnabled = b;

        }
        private void ShowOperandsButtons(bool b)
        {
            ButtonInc.IsEnabled = b;
            ButtonDec.IsEnabled = b;
            ButtonUmn.IsEnabled = b;
            ButtonDel.IsEnabled = b;
        }
        private void ShowResultButton(bool b)
        {
            ButtonResult.IsEnabled = b;
        }
        private void ShowDotButton(bool b)
        {
            ButtonDot.IsEnabled = b;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
