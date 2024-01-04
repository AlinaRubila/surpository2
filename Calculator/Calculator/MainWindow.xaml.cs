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

namespace Laboratory_Work_2_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        float a, a1, b;
        int operation;
        bool sign = true;
        bool IsEqual = false;
        string stroka;
        bool CheckBoxMode = false;
        private void calculate()
        {
            a1 = float.Parse(WINDOU.Text);
            if ((a1 == 0) && (operation == 4))
            {
                operation = 5;
            }
            switch (operation)
            {
                case 1:
                    b = a + a1;
                    stroka = a.ToString() + "+" + a1.ToString() + "=" + b.ToString();
                    WINDOU.Text = b.ToString();
                    break;
                case 2:
                    b = a - a1;
                    stroka = a.ToString() + "-" + a1.ToString() + "=" + b.ToString();
                    WINDOU.Text = b.ToString();
                    break;
                case 3:
                    b = a * a1;
                    stroka = a.ToString() + "*" + a1.ToString() + "=" + b.ToString();
                    WINDOU.Text = b.ToString();
                    break;
                case 4:
                    b = a / a1;
                    stroka = a.ToString() + "/" + a1.ToString() + "=" + b.ToString();
                    WINDOU.Text = b.ToString();
                    break;
                default:
                    stroka = a.ToString() + "/" + a1.ToString() + "=" + "ОШИБКА";
                    WINDOU.Text = "ТЫ ЧЕГО НАДЕЛАЛ, ГУМАНИТАРИЙ???!!!";
                    break;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e) //метод для цифр
        {
            if (IsEqual == true)
            {
                WINDOU.Clear();
                IsEqual = false;
            }
            WINDOU.Text += ((Button)sender).Content;
        }

        private void ButtonPLUS_Click(object sender, RoutedEventArgs e) //метод для плюса
        {
            a = float.Parse(WINDOU.Text);
            WINDOU.Clear();
            operation = 1;
            WHATSOLVE.Content = a.ToString() + "+";
            sign = true;
        }

        private void MINUS_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(WINDOU.Text);
            WINDOU.Clear();
            operation = 2;
            WHATSOLVE.Content = a.ToString() + "-";
            sign = true;
        }

        private void MULTY_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(WINDOU.Text);
            WINDOU.Clear();
            operation = 3;
            WHATSOLVE.Content = a.ToString() + "*";
            sign = true;
        }

        private void DIVIDE_Click(object sender, RoutedEventArgs e)
        {
            a = float.Parse(WINDOU.Text);
            WINDOU.Clear();
            operation = 4;
            WHATSOLVE.Content = a.ToString() + "/";
            sign = true;
        }

        private void PLUNUS_Click(object sender, RoutedEventArgs e)
        {
            if (sign == true)
            {
                sign = false;
                WINDOU.Text = "-" + WINDOU.Text;
            }
            else
            {
                float pm = float.Parse(WINDOU.Text) * (-1);
                WINDOU.Text = pm.ToString();
            }
        }

        private void EQUAL_Click(object sender, RoutedEventArgs e)
        {
            calculate();
            WHATSOLVE.Content = "";
            IsEqual = true;
            if (CheckBoxMode == true)
            {
                ListBoxy.Items.Add(stroka);
            }
            }

        private void BACKWARD_Click(object sender, RoutedEventArgs e)
        {
            int length = WINDOU.Text.Length - 1;
            string text = WINDOU.Text;
            WINDOU.Clear();
            for (int i = 0; i < length; i++)
            {
                WINDOU.Text += text[i];
            }
        }

        private void ClearAllButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxy.Items.Clear();
        }

        private void ClearLastButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxy.Items.RemoveAt(ListBoxy.Items.Count - 1);
        }

        private void VisibleButton_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxy.Visibility = Visibility.Visible;
            CheckyBOX.Visibility = Visibility.Visible;
            ClearAllButton.Visibility = Visibility.Visible;
            ClearLastButton.Visibility = Visibility.Visible;
        }

        private void InvisibleButton_Checked(object sender, RoutedEventArgs e)
        {
            ListBoxy.Visibility = Visibility.Hidden;
            CheckyBOX.Visibility = Visibility.Hidden;
            ClearAllButton.Visibility = Visibility.Hidden;
            ClearLastButton.Visibility = Visibility.Hidden;
        }

        private void CheckyBOX_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxMode == false)
            {
                CheckBoxMode = true;
            }
            else
            {
                CheckBoxMode = false;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            WINDOU.Text = "";
            WHATSOLVE.Content = "";
        }

    }
}
