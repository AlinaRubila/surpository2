using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
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

namespace LaboratoryWork_4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }
        private void NOTES_Activated(object sender, EventArgs e)
        {
            TheField.Text = File.ReadAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр4\LaboratoryWork 4\bin\Debug\SaveNotes.txt");
        }
        void NOTES_Closing(object sender, CancelEventArgs e)
        {
            int a = TheField.LineCount;
            int COUNT = 0;
            int eon = 0;
            for (int i = 0; i < a; i++)
            {
                string b = TheField.GetLineText(i);
                if (String.IsNullOrWhiteSpace(b) == false)
                {
                    eon = 1;
                    if (COUNT == 0)
                    {
                        File.WriteAllText(@"SaveNotes.txt", b);
                        COUNT += 1;
                    }
                    else 
                    {
                        File.AppendAllText(@"SaveNotes.txt", b);
                    }
                }
            }
            if (eon == 0)
            {
                File.WriteAllText(@"SaveNotes.txt", "");
            }
        }

        private void White_Selected(object sender, RoutedEventArgs e)
        {
            NOTES.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void Pink_Selected(object sender, RoutedEventArgs e)
        {
            NOTES.Background = new SolidColorBrush(Color.FromRgb(255, 220, 240));
        }

        private void Blue_Selected(object sender, RoutedEventArgs e)
        {
            NOTES.Background = new SolidColorBrush(Color.FromRgb(177, 236, 255));
        }

        private void SegoeUI_Selected(object sender, RoutedEventArgs e)
        {
            TheField.FontFamily = new FontFamily("Segoe UI");
        }

        private void TimesNewRoman_Selected(object sender, RoutedEventArgs e)
        {
            TheField.FontFamily = new FontFamily("Times New Roman");
        }

        private void Twelve_Selected(object sender, RoutedEventArgs e)
        {
            TheField.FontSize = 12;
        }

        private void Fifteen_Selected(object sender, RoutedEventArgs e)
        {
            TheField.FontSize = 15;
        }

        private void Eighteen_Selected(object sender, RoutedEventArgs e)
        {
            TheField.FontSize = 18;
        }
    }

}
