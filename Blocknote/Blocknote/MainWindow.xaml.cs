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
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.IO;
namespace Blocknote
{
    public partial class MainWindow : Window
    {
        bool IsSaved = true;
        bool NeedToOpenSD = true;
        bool NotClosing = false;
        string filename = "New Document";
        private void NeedToSave()
        {
            if (IsSaved == false)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Хотите сохраниться перед выходом?", "Сообщение", MessageBoxButton.YesNoCancel);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        if (NeedToOpenSD == false)
                        {
                            File.WriteAllText(filename, TEXT_FIELD.Text);
                        }
                        else
                        {
                            SaveFileDialog SaveFiles = new SaveFileDialog();
                            SaveFiles.DefaultExt = ".txt";
                            SaveFiles.FileName = filename;
                            SaveFiles.Filter = "Text documents (.txt)|*.txt";
                            SaveFiles.ShowDialog();
                            File.WriteAllText(SaveFiles.FileName, TEXT_FIELD.Text);
                        }
                        IsSaved = true;
                        NotClosing = false;
                        break;
                    case MessageBoxResult.No:
                        NotClosing = false;
                        break;
                    case MessageBoxResult.Cancel:
                        NotClosing = true;
                        break;
                }
            }
        }
        private void OPENFILE(object sender, RoutedEventArgs e)
        {
            var OpenFiles = new Microsoft.Win32.OpenFileDialog();
            OpenFiles.DefaultExt = ".txt";
            OpenFiles.FileName = filename;
            OpenFiles.Filter = "Text documents (.txt)|*.txt";
            if (OpenFiles.ShowDialog() == true)
            {
                filename = OpenFiles.FileName;
                TEXT_FIELD.Text = File.ReadAllText(OpenFiles.FileName);
            }
            NeedToOpenSD = false;
        }
        private void CREATE_NEW_DOCUMENT(object sender, RoutedEventArgs e)
        {
            NeedToSave();
            if (NotClosing == false)
            {
                TEXT_FIELD.Clear();
                filename = "New Document";
            }
            NeedToOpenSD = true;
        }
        private void EXIT_APPLICATION(object sender, RoutedEventArgs e)
        {
             MAIN_WINDOW.Close(); 
        }

        private void SAVE_CLICK(object sender, RoutedEventArgs e)
        {
            if (NeedToOpenSD == false)
            {
                File.WriteAllText(filename, TEXT_FIELD.Text);
            }
            else
            {
                SaveFileDialog SaveFiles = new SaveFileDialog();
                SaveFiles.DefaultExt = ".txt";
                SaveFiles.FileName = filename;
                SaveFiles.Filter = "Text documents (.txt)|*.txt";
                SaveFiles.ShowDialog();
                File.WriteAllText(SaveFiles.FileName, TEXT_FIELD.Text);
                filename = SaveFiles.FileName;
            }
            IsSaved = true;
        }
        private void SAVE_AS_CLICK(object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFiles = new SaveFileDialog();
            SaveFiles.DefaultExt = ".txt";
            SaveFiles.FileName = filename;
            SaveFiles.Filter = "Text documents (.txt)|*.txt";
            SaveFiles.ShowDialog();
            File.WriteAllText(SaveFiles.FileName, TEXT_FIELD.Text);
            filename = SaveFiles.FileName;
            IsSaved = true;
        }
        private void Segoe_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.FontFamily = new FontFamily("Segoe UI");
        }
        private void TNR_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.FontFamily = new FontFamily("Times New Roman");
        }
        private void Comic_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.FontFamily = new FontFamily("Comic Sans MS");
        }
        private void Black_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.Foreground = new SolidColorBrush(Color.FromRgb(33, 33, 33));
        }
        private void Red_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.Foreground = new SolidColorBrush(Color.FromRgb(163, 0, 0));
        }
        private void Blue_Chosen(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 219));
        }

        private void TEXT_FIELD_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsSaved = false;
        }

        private void Closing_MainWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NeedToSave();
            if (NotClosing == true)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        private void DATE_TIME_CLICK(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;
            TEXT_FIELD.Text += now.ToString("G");
        }
        private void SELECT_ALL_Click(object sender, RoutedEventArgs e)
        {
            TEXT_FIELD.SelectAll();
        }
    }
}
