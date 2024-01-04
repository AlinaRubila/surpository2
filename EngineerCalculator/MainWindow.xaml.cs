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
using System.IO;
namespace Cursach
{
    public partial class MainWindow : Window
    {
        private void CALCILATOR_Activated(object sender, EventArgs e)
        {
            MEMORY.Text = File.ReadAllText(@"C:\Users\angry\OneDrive\Рабочий стол\Cursach\SaveMemory.txt");
        }
        bool IsStarted = true;
        bool OpActive = false; //начата ли какая-либо долгая арифметическая операция
        int OpCode = 0;
        bool PointGot = false;
        int DegRadMode = 1; //1 - градусы, 2 - радианы
        double a, b, c;
        string stroka;
        bool LeftBracketPut = false;
        bool RightBracketPut = false;
        int SubOpCode = 0;
        double SubA, SubB, SubC;
        private void UpdateVar()
        {
            IsStarted = true;
            PointGot = false;
        }
        private string Brackets(double x) //ставит скобки для отрицательных чисел
        {
            string x1;
            if (x < 0)
            {
                x1 = "(" + x.ToString() + ")";
            }
            else
            {
                x1 = x.ToString();
            }
            return x1;
        }
        private void calculate()
        {int s = int.Parse(ROUNDING.Text);
            b = double.Parse(WINDOU.Text);
            if ((OpCode == 4) && (b == 0))
            {OpCode = 8;}
            if ((OpCode == 6) && (((b % 2 == 0) && (a < 0)) || (b == 0)))
            {OpCode = 8;}
            if ((OpCode == 7) && ((a < 0) || (b < 0) || (b == 1)))
            {OpCode = 8;}
            switch (OpCode)
            {case 1: c = Math.Round(a + b, s); break;
                case 2: c = Math.Round(a - b, s); break;
                case 3: c = Math.Round(a * b, s); break;
                case 4: c = Math.Round(a / b, s); break;
                case 5: c = Math.Round(Math.Pow(a, b), s); break;
                case 6: c = Math.Round(Math.Pow(a, 1 / b), s); break;
                case 7: c = Math.Round(Math.Log(a, b), s); break;
                default: break;}
            if (RightBracketPut == false)
            {stroka = WHATSOLVE.Content + Brackets(b) + "=";}
            else
            {stroka = WHATSOLVE.Content + "=";}
            if (OpCode != 8)
            {stroka += c.ToString();}
            else
            {stroka += "ОШИБКА";}
            HISTORY.Items.Add(stroka);}
        //редактирование ввода
        private void C_BUTTON_Click(object sender, RoutedEventArgs e) //метод для кнопки C
        {
            WINDOU.Text = "0";
            WHATSOLVE.Content = "";
            UpdateVar();
        }
        private void BACKWARDS_Click(object sender, RoutedEventArgs e)
        {
            int l = WINDOU.Text.Length - 1;
            string tet = WINDOU.Text;
            if (tet[l] == ',')
            {
                PointGot = false;
            }
            else if (tet[l] == '(')
            {
                LeftBracketPut = false;
            }
            WINDOU.Clear();
            for (int i = 0; i < l; i++)
            {
                WINDOU.Text += tet[i];
            }
        }
        //работа с числами и их сборка
        private void DIGIT_Click(object sender, RoutedEventArgs e) //метод для цифр кроме 0
        {
            if (IsStarted == true)
            {
                WINDOU.Clear();
                if (OpCode == 0 && (LeftBracketPut != true && RightBracketPut == false))
                {
                    WHATSOLVE.Content = "";
                }
                IsStarted = false;
            }
            WINDOU.Text += ((Button)sender).Content;
        }
        private void ZERO_Click(object sender, RoutedEventArgs e) //метод для 0
        {
            if ((IsStarted == false) && (WINDOU.Text != "0"))
            {
                WINDOU.Text += ZERO.Content;
            }
            else if (OpCode != 0)
            {
                WINDOU.Text = "0";
                IsStarted = false;
            }
            else if (SubOpCode != 0)
            {
                WINDOU.Text = "0";
                IsStarted = false;
            }
        }
        private void E_DIGIT_Click(object sender, RoutedEventArgs e) //метод для е
        {
            if ((IsStarted == true))
            {
                WINDOU.Clear();
                if (OpCode == 0 && (LeftBracketPut != true && RightBracketPut == false))
                {
                    WHATSOLVE.Content = "";
                }
                IsStarted = false;
            }
            int s = int.Parse(ROUNDING.Text);
            WINDOU.Text = Math.Round(Math.E, s).ToString();
        }
        private void PI_DIGIT_Click(object sender, RoutedEventArgs e) //метод для числа пи
        {
            if ((IsStarted == true))
            {
                WINDOU.Clear();
                if (OpCode == 0 && (LeftBracketPut != true && RightBracketPut == false))
                {
                    WHATSOLVE.Content = "";
                }
                IsStarted = false;
            }
            int s = int.Parse(ROUNDING.Text);
            WINDOU.Text = Math.Round(Math.PI, s).ToString();
        }
        private void POINT_Click(object sender, RoutedEventArgs e) //метод для запятой
        {
            if (PointGot == false)
            {
                IsStarted = false;
                PointGot = true;
                WINDOU.Text += ",";
            }
        }
        private void PLUNUS_Click(object sender, RoutedEventArgs e) //метод для + -
        {
            string tet = WINDOU.Text;
            if (IsStarted == false && (LeftBracketPut != true || tet[0] != '('))
            {
                double p = double.Parse(WINDOU.Text) * (-1);
                WINDOU.Text = p.ToString();
            }
            else if (IsStarted == false && LeftBracketPut == true)
            {
                int l = WINDOU.Text.Length;
                string FromWindow = WINDOU.Text;
                string TextP = "";
                for (int i = 1; i < l; i++)
                {
                    TextP += FromWindow[i];
                }
                double p = double.Parse(TextP) * (-1);
                WINDOU.Text = "(" + p.ToString();
            }
        }
        private void DEG_CHOICE_Checked(object sender, RoutedEventArgs e)
        {
            DegRadMode = 1;
        }
        private void RAD_CHOICE_Checked(object sender, RoutedEventArgs e)
        {
            DegRadMode = 2;
        }
        //арифметические действия с двумя числами
        private void PLUS_Click(object sender, RoutedEventArgs e){ //метод для плюса
            if (LeftBracketPut == true){
                int l = WINDOU.Text.Length;
                string FromWindow = WINDOU.Text;
                string TextSubA = "";
                for (int i = 1; i < l; i++) {TextSubA += FromWindow[i];}
                SubA = double.Parse(TextSubA);
                SubOpCode = 1;
                WINDOU.Text += "+";
                WHATSOLVE.Content += WINDOU.Text;}
            else
            {
                if (OpActive == true)
                {calculate();
                    a = c;}
                else {a = double.Parse(WINDOU.Text);}
                OpCode = 1;
                WHATSOLVE.Content = a.ToString() + "+";
                OpActive = true;
                RightBracketPut = false;}
            UpdateVar();
        }
        private void MINUS_Click(object sender, RoutedEventArgs e) { //метод для минуса
            if (LeftBracketPut == true) {
                int l = WINDOU.Text.Length;
                string FromWindow = WINDOU.Text;
                string TextSubA = "";
                for (int i = 1; i < l; i++) {TextSubA += FromWindow[i];}
                SubA = double.Parse(TextSubA);
                SubOpCode = 2;
                WINDOU.Text += "-";
                WHATSOLVE.Content += WINDOU.Text;}
            else
            {
                if (OpActive == true)
                {calculate();
                    a = c;}
                else{a = double.Parse(WINDOU.Text);}
                OpCode = 2;
                WHATSOLVE.Content = a.ToString() + "-";
                OpActive = true;
                RightBracketPut = false;}
            UpdateVar();
        }
        private void MULTY_Click(object sender, RoutedEventArgs e) {//метод для умножения
            if (LeftBracketPut == true){
                int l = WINDOU.Text.Length;
                string FromWindow = WINDOU.Text;
                string TextSubA = "";
                for (int i = 1; i < l; i++) {TextSubA += FromWindow[i];}
                SubA = double.Parse(TextSubA);
                SubOpCode = 3;
                WINDOU.Text += "*";
                WHATSOLVE.Content += WINDOU.Text;}
            else
            {
                if (OpActive == true) {
                    calculate();
                    a = c;}
                else {a = double.Parse(WINDOU.Text);}
                OpCode = 3;
                WHATSOLVE.Content = a.ToString() + "*";
                OpActive = true;
                RightBracketPut = false;}
            UpdateVar();
        }
        private void DIVIDE_Click(object sender, RoutedEventArgs e) { //метод для деления
            if (LeftBracketPut == true) {
                int l = WINDOU.Text.Length;
                string FromWindow = WINDOU.Text;
                string TextSubA = "";
                for (int i = 1; i < l; i++) {TextSubA += FromWindow[i];}
                SubA = double.Parse(TextSubA);
                SubOpCode = 4;
                WINDOU.Text += "/";
                WHATSOLVE.Content += WINDOU.Text;}
            else
            {
                if (OpActive == true){
                    calculate();
                    a = c;}
                else {a = double.Parse(WINDOU.Text);}
                OpCode = 4;
                WHATSOLVE.Content = a.ToString() + "/";
                OpActive = true;
                RightBracketPut = false;}
            UpdateVar();
        }
        private void DEGREE_Click(object sender, RoutedEventArgs e){ //метод для степени
            if (OpActive == true)
            {calculate();
                a = c;}
            else {a = double.Parse(WINDOU.Text);}
            OpCode = 5;
            WHATSOLVE.Content = Brackets(a) + "^";
            OpActive = true;
            RightBracketPut = false;
            UpdateVar();}
        private void ROOT_Click(object sender, RoutedEventArgs e){ //метод для корня
            if (OpActive == true){
                calculate();
                a = c;}
            else {a = double.Parse(WINDOU.Text);}
            OpCode = 6;
            WHATSOLVE.Content = "√" + Brackets(a) + " степени ";
            OpActive = true;
            RightBracketPut = false;
            UpdateVar();}
        private void LOG_Click(object sender, RoutedEventArgs e){ //метод для логарифма
            if (OpActive == true){
                calculate();
                a = c;}
            else {a = double.Parse(WINDOU.Text);}
            OpCode = 7;
            WHATSOLVE.Content = "log " + Brackets(a) + " по основанию ";
            OpActive = true;
            RightBracketPut = false;
            UpdateVar();}
        //операции в один клик
        private void FACTOR_Click(object sender, RoutedEventArgs e) //метод для факториала
        {
            double n = double.Parse(WINDOU.Text);
            int f = 1;
            if ((n % 1 == 0) && (n > 0))
            {
                for (int i = 2; i <= n;i++)
                {
                    f *= i;
                }
                WINDOU.Text = f.ToString();
            }
            else if (n == 0)
            {
                WINDOU.Text = "1";
            }
            else 
            {
                WINDOU.Text = "ОШИБКА";
            }
            WHATSOLVE.Content = Brackets(n) + "!" + "=";
            stroka = Brackets(n) + "!" + "=" + WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();
        }
        private void SECOND_DEGREE_Click(object sender, RoutedEventArgs e){ //метод для второй степени
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            double a1 = Math.Round(Math.Pow(x,2), s);
            WINDOU.Text = a1.ToString();
            WHATSOLVE.Content = Brackets(x) + "^" + "2" + "=";
            stroka = Brackets(x) + "^" + "2" + "=" + a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void SQUARE_ROOT_Click(object sender, RoutedEventArgs e){ //метод для корня квадратного
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            if (x >= 0){
                double a1 = Math.Round(Math.Sqrt(x), s);
                WINDOU.Text = a1.ToString();}
            else {WINDOU.Text = "ОШИБКА";}
            WHATSOLVE.Content = "√" + Brackets(x) + "=";
            stroka = "√" + Brackets(x) + "=" + WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void MODULE_Click(object sender, RoutedEventArgs e) //метод для модуля
        {
            double x = double.Parse(WINDOU.Text);
            double a1 = Math.Abs(x);
            WINDOU.Text = a1.ToString();
            WHATSOLVE.Content = "|" + x.ToString() + "|" + "=";
            stroka = "|" + x.ToString() + "|" + "=" + a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();
        }
        private void REVERSE_X_Click(object sender, RoutedEventArgs e){ //метод для обратного икса
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            if (x != 0) {
                double a1 = Math.Round(1 / x, s);
                WINDOU.Text = a1.ToString();}
            else {WINDOU.Text = "ОШИБКА";}
            WHATSOLVE.Content = "1" + "/" + Brackets(x) + "=";
            stroka = "1" + "/" + Brackets(x) + "=" + WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void E_LOG_Click(object sender, RoutedEventArgs e) //метод для натурального логарифма
        {
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            if (x > 0)
            {
                double a1 = Math.Round(Math.Log(x), s);
                WINDOU.Text = a1.ToString();
            }
            else
            {
                WINDOU.Text = "ОШИБКА";
            }
            WHATSOLVE.Content = "ln " + Brackets(x) + "=";
            stroka = "ln " + Brackets(x) + "=" + WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();
        }
        //тригонометрия
        private void SIN_Selected(object sender, RoutedEventArgs e) //вычисление синуса
        {
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            WHATSOLVE.Content = "sin " + Brackets(x) + "=";
            stroka = "sin " + Brackets(x) + "=";
            if (DegRadMode == 1)
            {
                x = x * Math.PI / 180;
            }
            double a1 = Math.Round(Math.Sin(x), s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();
        }
        private void COS_Selected(object sender, RoutedEventArgs e) { //косинус
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            WHATSOLVE.Content = "cos " + Brackets(x) + "=";
            stroka = "cos " + Brackets(x) + "=";
            if (DegRadMode == 1) {x = x * Math.PI / 180;}
            double a1 = Math.Round(Math.Cos(x), s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void TG_Selected(object sender, RoutedEventArgs e) { //тангенс
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            WHATSOLVE.Content = "tg " + Brackets(x) + "=";
            stroka = "tg " + Brackets(x) + "=";
            if (DegRadMode == 1) {x = x * Math.PI / 180;}
            if ((x % (Math.PI / 2) == 0) && (x % (Math.PI) != 0) && (x != 0)) {WINDOU.Text = "ОШИБКА";}
            else {
                double a1 = Math.Round(Math.Tan(x), s);
                WINDOU.Text = a1.ToString();}
            stroka += WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void CTG_Selected(object sender, RoutedEventArgs e) { //котангенс
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            WHATSOLVE.Content = "ctg " + Brackets(x) + "=";
            stroka = "ctg " + Brackets(x) + "=";
            if (DegRadMode == 1) {x = x * Math.PI / 180;}
            if (Math.Tan(x) == 0) {WINDOU.Text = "ОШИБКА";}
            else {
                double a1 = Math.Round(1 / Math.Tan(x), s);
                WINDOU.Text = a1.ToString();}
            stroka += WINDOU.Text;
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void ARCSIN_Selected(object sender, RoutedEventArgs e) //арксинус
        {
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            double a1 = Math.Asin(x);
            WHATSOLVE.Content = "arcsin " + Brackets(x) + "=";
            stroka = "arcsin " + Brackets(x) + "=";
            if (DegRadMode == 1)
            {
                a1 = a1 * 180 / Math.PI;
            }
            a1 = Math.Round(a1, s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();
        }
        private void ARCCOS_Selected(object sender, RoutedEventArgs e) { //арккосинус
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            double a1 = Math.Acos(x);
            WHATSOLVE.Content = "arccos " + Brackets(x) + "=";
            stroka = "arccos " + Brackets(x) + "=";
            if (DegRadMode == 1) {a1 = a1 * 180 / Math.PI;}
            a1 = Math.Round(a1, s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void ARCTG_Selected(object sender, RoutedEventArgs e) { //арктангенс
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            double a1 = Math.Atan(x);
            WHATSOLVE.Content = "arctg " + Brackets(x) + "=";
            stroka = "arctg " + Brackets(x) + "=";
            if (DegRadMode == 1) {a1 = a1 * 180 / Math.PI;}
            a1 = Math.Round(a1, s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        private void ARCCTG_Selected(object sender, RoutedEventArgs e) { //арккотангенс
            double x = double.Parse(WINDOU.Text);
            int s = int.Parse(ROUNDING.Text);
            double a1 = (Math.PI / 2) - Math.Atan(x);
            WHATSOLVE.Content = "arcctg " + Brackets(x) + "=";
            stroka = "arcctg " + Brackets(x) + "=";
            if (DegRadMode == 1) {a1 = a1 * 180 / Math.PI;}
            a1 = Math.Round(a1, s);
            WINDOU.Text = a1.ToString();
            stroka += a1.ToString();
            HISTORY.Items.Add(stroka);
            UpdateVar();}
        //работа с памятью
        private void MS_Click(object sender, RoutedEventArgs e){ //запись в память
            MEMORY.Text = WINDOU.Text;}
        private void MR_Click(object sender, RoutedEventArgs e){ //вывод из памяти
            WINDOU.Text = MEMORY.Text;}
        private void MC_Click(object sender, RoutedEventArgs e){ //очистка памяти
            MEMORY.Clear();}
        private void M_PLUS_Click(object sender, RoutedEventArgs e){ //увеличение памяти
            double m1 = double.Parse(MEMORY.Text) + double.Parse(WINDOU.Text);
            MEMORY.Text = m1.ToString();}
        private void M_MINUS_Click(object sender, RoutedEventArgs e){ //уменьшение памяти
            double m1 = double.Parse(MEMORY.Text) - double.Parse(WINDOU.Text);
            MEMORY.Text = m1.ToString();}
        private void SAVE_ON_COMPUTER_Click(object sender, RoutedEventArgs e)
        {File.WriteAllText(@"C:\Users\angry\OneDrive\Рабочий стол\Cursach\SaveMemory.txt", MEMORY.Text);}

        private void LEFT_BRAKET_Click(object sender, RoutedEventArgs e){
            LeftBracketPut = true;
            if (IsStarted == true){
                WINDOU.Text = "(";
                IsStarted = false;
                RightBracketPut = false;}}
        private void RIGHT_BRACET_Click(object sender, RoutedEventArgs e){
            SubB = double.Parse(WINDOU.Text);
            if (SubOpCode == 4 && SubB == 0) {SubOpCode = 5;}
            switch (SubOpCode){
                case 1: SubC = SubA + SubB; break;
                case 2: SubC = SubA - SubB; break;
                case 3: SubC = SubA * SubB; break;
                case 4: SubC = SubA / SubB; break;
                default: break;}
            WHATSOLVE.Content += WINDOU.Text + ")";
            if (SubOpCode != 5) {WINDOU.Text = SubC.ToString();}
            else
            { WINDOU.Text = "ОШИБКА";}
            LeftBracketPut = false;
            SubOpCode = 0;
            UpdateVar();
            RightBracketPut = true;}
        private void EQUAL_Click(object sender, RoutedEventArgs e) //равно
        {
            calculate();
            if (OpCode == 8) {WINDOU.Text = "ОШИБКА";}
            else {WINDOU.Text = c.ToString();}
            if (RightBracketPut == false) {WHATSOLVE.Content += Brackets(b) + "=";}
            else {WHATSOLVE.Content += "=";}
            UpdateVar();
            OpCode = 0;
            OpActive = false;
            LeftBracketPut = false;
            RightBracketPut = false;}
        //цветовые темы
        private void STANDART_Selected(object sender, RoutedEventArgs e) { //стандартная
            ALSO_WINDOU.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            C_BUTTON.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            BACKWARDS.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            DEGREE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            REVERSE_X.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            MODULE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221)); 
            SQUARE_ROOT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            SECOND_DEGREE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            ROOT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            LEFT_BRAKET.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            RIGHT_BRACET.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            FACTOR.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            PLUS.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            E_LOG.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            ONE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            TWO.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            THREE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            MINUS.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            LOG.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            FOUR.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            FIVE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            SIX.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            MULTY.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            PI_DIGIT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            SEVEN.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            EIGHT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            NINE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            DIVIDE.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            E_DIGIT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            PLUNUS.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            ZERO.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            POINT.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
            EQUAL.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));}
        private void PASTEL_Selected(object sender, RoutedEventArgs e) { //пастельная
            ALSO_WINDOU.Background = new SolidColorBrush(Color.FromRgb(255, 217, 239));
            C_BUTTON.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            BACKWARDS.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            DEGREE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            REVERSE_X.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            MODULE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            SQUARE_ROOT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            SECOND_DEGREE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            ROOT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            LEFT_BRAKET.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            RIGHT_BRACET.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            FACTOR.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            PLUS.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            E_LOG.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            ONE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            TWO.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            THREE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            MINUS.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            LOG.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            FOUR.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            FIVE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            SIX.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            MULTY.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            PI_DIGIT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            SEVEN.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            EIGHT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            NINE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            DIVIDE.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            E_DIGIT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            PLUNUS.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            ZERO.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            POINT.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));
            EQUAL.Background = new SolidColorBrush(Color.FromRgb(196, 235, 255));}
        private void CLASSIC_Selected(object sender, RoutedEventArgs e) { //классическая
            ALSO_WINDOU.Background = new SolidColorBrush(Color.FromRgb(161, 161, 161));
            C_BUTTON.Background = new SolidColorBrush(Color.FromRgb(255, 183, 94));
            BACKWARDS.Background = new SolidColorBrush(Color.FromRgb(255, 183, 94));
            DEGREE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            REVERSE_X.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            MODULE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            SQUARE_ROOT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            SECOND_DEGREE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            ROOT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            LEFT_BRAKET.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            RIGHT_BRACET.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            FACTOR.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            PLUS.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            E_LOG.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            ONE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            TWO.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            THREE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            MINUS.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            LOG.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            FOUR.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            FIVE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            SIX.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            MULTY.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            PI_DIGIT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            SEVEN.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            EIGHT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            NINE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            DIVIDE.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            E_DIGIT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            PLUNUS.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            ZERO.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            POINT.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));
            EQUAL.Background = new SolidColorBrush(Color.FromRgb(206, 206, 206));}
        private void PreviewKeyDown_CALCY(object sender, KeyEventArgs e) {
            if (ROUNDING.IsFocused != true)
            {
                if ((e.Key > Key.D0 && e.Key <= Key.D9 && e.KeyboardDevice.Modifiers != ModifierKeys.Shift) || (e.Key > Key.NumPad0 && e.Key <= Key.NumPad9)) //ввод цифр
                {if (IsStarted == true)
                    {WINDOU.Clear();
                        if (OpCode == 0 && (LeftBracketPut == false && RightBracketPut == false)) {WHATSOLVE.Content = "";}
                     IsStarted = false;}
                    KeyConverter converter = new KeyConverter();
                    string key = converter.ConvertToString(e.Key);
                    WINDOU.Text += key;}
                if ((e.Key == Key.D0 && e.KeyboardDevice.Modifiers != ModifierKeys.Shift) || e.Key == Key.NumPad0)
                {if ((IsStarted == false) && (WINDOU.Text != "0")) {WINDOU.Text += ZERO.Content;}
                    else if (OpCode != 0)
                    {WINDOU.Text = "0";
                     IsStarted = false;}
                    else if (SubOpCode != 0)
                    {WINDOU.Text = "0";
                     IsStarted = false;}}
                if (e.Key == Key.Back)
                {int l = WINDOU.Text.Length - 1;
                 string tet = WINDOU.Text;
                 char lastChar = tet[l];
                 if (lastChar == ',') {PointGot = false;}
                 else if (lastChar == '(') {LeftBracketPut = false;}
                 WINDOU.Clear();
                 for (int i = 0; i < l; i++) {WINDOU.Text += tet[i];}
                }
            }
                if (e.Key == Key.OemComma || (e.KeyboardDevice.Modifiers == ModifierKeys.Shift && e.Key == Key.OemQuestion)) //ввод точки-запятой
                {if (PointGot == false)
                 {IsStarted = false;
                  PointGot = true;
                  WINDOU.Text += ",";}}
                if (e.Key == Key.OemPlus || e.Key == Key.Add) { //ввод плюса
                if (LeftBracketPut == true) {
                    int l = WINDOU.Text.Length;
                    string FromWindow = WINDOU.Text;
                    string TextSubA = "";
                    for (int i = 1; i < l; i++) {TextSubA += FromWindow[i];}
                    SubA = double.Parse(TextSubA);
                    SubOpCode = 1;
                    WINDOU.Text += "+";
                    WHATSOLVE.Content += WINDOU.Text;}
                else
                {
                    if (OpActive == true)
                    {calculate();
                     a = c;}
                    else {a = double.Parse(WINDOU.Text);}
                    OpCode = 1;
                    WHATSOLVE.Content = a.ToString() + "+";
                    OpActive = true;
                    RightBracketPut = false;
                }
                UpdateVar();}
                if (e.Key == Key.OemMinus || e.Key == Key.Subtract) //ввод минуса
                {
                if (LeftBracketPut == true)
                {
                    int l = WINDOU.Text.Length;
                    string FromWindow = WINDOU.Text;
                    string TextSubA = "";
                    for (int i = 1; i < l; i++)
                    {
                        TextSubA += FromWindow[i];
                    }
                    SubA = double.Parse(TextSubA);
                    SubOpCode = 2;
                    WINDOU.Text += "-";
                    WHATSOLVE.Content += WINDOU.Text;
                    UpdateVar();
                }
                else
                {
                    if (OpActive == true)
                    {
                        calculate();
                        a = c;
                    }
                    else
                    {
                        a = double.Parse(WINDOU.Text);
                    }
                    OpCode = 2;
                    WHATSOLVE.Content = a.ToString() + "-";
                    OpActive = true;
                    RightBracketPut = false;
                    UpdateVar();
                }
                }
                if ((e.Key == Key.D8 && e.KeyboardDevice.Modifiers == ModifierKeys.Shift) || e.Key == Key.Multiply) //ввод умножения
                {
                if (LeftBracketPut == true)
                {
                    int l = WINDOU.Text.Length;
                    string FromWindow = WINDOU.Text;
                    string TextSubA = "";
                    for (int i = 1; i < l; i++)
                    {
                        TextSubA += FromWindow[i];
                    }
                    SubA = double.Parse(TextSubA);
                    SubOpCode = 3;
                    WINDOU.Text += "*";
                    WHATSOLVE.Content += WINDOU.Text;
                    UpdateVar();
                }
                else
                {
                    if (OpActive == true)
                    {
                        calculate();
                        a = c;
                    }
                    else
                    {
                        a = double.Parse(WINDOU.Text);
                    }
                    OpCode = 3;
                    WHATSOLVE.Content = a.ToString() + "*";
                    OpActive = true;
                    RightBracketPut = false;
                    UpdateVar();
                }
                }
                if ((e.Key == Key.OemQuestion && e.KeyboardDevice.Modifiers != ModifierKeys.Shift) || e.Key == Key.Divide)
                {
                if (LeftBracketPut == true)
                {
                    int l = WINDOU.Text.Length;
                    string FromWindow = WINDOU.Text;
                    string TextSubA = "";
                    for (int i = 1; i < l; i++)
                    {
                        TextSubA += FromWindow[i];
                    }
                    SubA = double.Parse(TextSubA);
                    SubOpCode = 4;
                    WINDOU.Text += "/";
                    WHATSOLVE.Content += WINDOU.Text;
                    UpdateVar();
                }
                else
                {
                    if (OpActive == true)
                    {
                        calculate();
                        a = c;
                    }
                    else
                    {
                        a = double.Parse(WINDOU.Text);
                    }
                    OpCode = 4;
                    WHATSOLVE.Content = a.ToString() + "/";
                    OpActive = true;
                    RightBracketPut = false;
                    UpdateVar();
                }
                }
            if (e.Key == Key.D9 && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                LeftBracketPut = true;
                if (IsStarted == true)
                {
                    WINDOU.Text = "(";
                    IsStarted = false;
                    RightBracketPut = false;
                }
            }
            if (e.Key == Key.D0 && e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            {
                SubB = double.Parse(WINDOU.Text);
                if (SubOpCode == 4 && SubB == 0)
                {
                    SubOpCode = 5;
                }
                switch (SubOpCode)
                {
                    case 1:
                        SubC = SubA + SubB;
                        break;
                    case 2:
                        SubC = SubA - SubB;
                        break;
                    case 3:
                        SubC = SubA * SubB;
                        break;
                    case 4:
                        SubC = SubA / SubB;
                        break;
                    default:
                        break;
                }
                WHATSOLVE.Content += WINDOU.Text + ")";
                if (SubOpCode != 5)
                {
                    WINDOU.Text = SubC.ToString();
                }
                else
                {
                    WINDOU.Text = "ОШИБКА";
                }
                LeftBracketPut = false;
                SubOpCode = 0;
                UpdateVar();
                RightBracketPut = true;
            }
            if (e.Key == Key.Enter)
            {
                calculate();
                if (OpCode == 8)
                {
                    WINDOU.Text = "ОШИБКА";
                }
                else
                {
                    WINDOU.Text = c.ToString();
                }
                if (RightBracketPut == false)
                {
                    WHATSOLVE.Content += Brackets(b) + "=";
                }
                else
                {
                    WHATSOLVE.Content += "=";
                }
                UpdateVar();
                OpCode = 0;
                OpActive = false;
                LeftBracketPut = false;
                RightBracketPut = false;
            }
        }
    }
}
