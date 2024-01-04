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
using System.Speech;
using System.Speech.Synthesis;
using Microsoft.Win32;
using System.IO;
using System.Speech.AudioFormat;

namespace MyImaginaryFriend
{
    public partial class MainWindow : Window
    {
        SpeechSynthesizer MyFriend = new SpeechSynthesizer();
        PromptBuilder Phrase = new PromptBuilder();
        bool SayHi = false;
        private void VoiceOfFriend_Click(object sender, RoutedEventArgs e)
        {
            Phrase.ClearContent();
            PromptStyle Tone = new PromptStyle();
            Tone.Rate = PromptRate.Slow;
            Phrase.StartStyle(Tone);
            if (SayHi == true)
            {
                Phrase.AppendText("Привет!");
            }
            Phrase.AppendText(TextToSay.Text);
            Phrase.EndStyle();
            MyFriend.Speak(Phrase);
        }
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            TextToSay.Clear();
        }
        private void HelloOrNot_Checked(object sender, RoutedEventArgs e)
        {
            SayHi = true;
        }
        private void HelloOrNotUnchecked(object sender, RoutedEventArgs e)
        {
            SayHi = false;
        }
        private void OpenText_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenTXT = new OpenFileDialog();
            OpenTXT.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (OpenTXT.ShowDialog() == true)
            {
                TextToSay.Text = File.ReadAllText(OpenTXT.FileName);
            }
        }
        private void SaveResult_Click(object sender, RoutedEventArgs e)
        {
            string SpeechName = NameOfFile.Text + ".wav";
            MyFriend.SetOutputToWaveFile(SpeechName);
            MyFriend.Speak(Phrase);
        }
    }
}
