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
using Microsoft.Win32;
using System.IO;

namespace AudioPlayer
{
    public partial class MainWindow : Window
    {
        string PlayingFile = "";
        int PlayListIndex = 0;
        string NameOfSong;
        private MediaPlayer AudioPlay = new MediaPlayer();
        private void Application_Activated(object sender, EventArgs e)
        {
            if (File.ReadAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\IsPlaylistCreated.txt") == "true")
            {
                string[] FS = File.ReadAllLines(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PlayListSaver.txt");
                string[] FP = File.ReadAllLines(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PathSaver.txt");
                for (int i = 0; i < FS.Length; i++)
                {
                    ListOfSongs.Items.Add(FS[i]);
                    ListOfPaths.Items.Add(FP[i]);
                }
                ListOfSongs.Visibility = Visibility.Visible;
                AddSongs.Visibility = Visibility.Visible;
                ClearAll.Visibility = Visibility.Visible;
                SavePlaylist.Visibility = Visibility.Visible;
                PlayPlaylist.Visibility = Visibility.Visible;
            }
        }
        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "MP3 files(*.mp3)|*.mp3|All files (*.*)|*.*";
            if (OFD.ShowDialog() == true)
            {
                PlayingFile = OFD.FileName;
                AudioPlay.Open(new Uri(PlayingFile));
                AudioPlay.Play();
                MusicCover.Visibility = Visibility.Visible;
                PlayAudio.Visibility = Visibility.Visible;
                PauseAudio.Visibility = Visibility.Visible;
                StopAudio.Visibility = Visibility.Visible;
                NameOfAudio.Visibility = Visibility.Visible;
                NameOfAudio.Text = OFD.SafeFileName;
            }
        }
        private void PlayAudio_Click(object sender, RoutedEventArgs e)
        {
            AudioPlay.Play();
        }
        private void PauseAudio_Click(object sender, RoutedEventArgs e)
        {
            AudioPlay.Pause();
        }
        private void StopAudio_Click(object sender, RoutedEventArgs e)
        {
            AudioPlay.Stop();
        }
        private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
        {
            ListOfSongs.Visibility = Visibility.Visible;
            AddSongs.Visibility = Visibility.Visible;
            ClearAll.Visibility = Visibility.Visible;
            SavePlaylist.Visibility = Visibility.Visible;
        }
        private void AddSongs_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog AddNewSong = new OpenFileDialog();
            AddNewSong.Multiselect = true;
            AddNewSong.Filter = "MP3 files(*.mp3)|*.mp3|All files (*.*)|*.*";
            if (AddNewSong.ShowDialog() == true)
            {
                foreach(string filename in AddNewSong.FileNames)
                {
                    ListOfPaths.Items.Add(System.IO.Path.GetFullPath(filename));
                    ListOfSongs.Items.Add(System.IO.Path.GetFileName(filename));
                    PlayPlaylist.Visibility = Visibility.Visible;
                }
            }
        }
        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            ListOfSongs.Items.Clear();
            ListOfPaths.Items.Clear();
            File.WriteAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PlayListSaver.txt", "");
            File.WriteAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PathSaver.txt", "");
            File.WriteAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\IsPlaylistCreated.txt", "false");
        }

        private void PlayPlaylist_Click(object sender, RoutedEventArgs e)
        {
            Backward.Visibility = Visibility.Visible;
            Forward.Visibility = Visibility.Visible;
            PlayingFile = ListOfPaths.Items.GetItemAt(0).ToString();
            NameOfSong = ListOfSongs.Items.GetItemAt(0).ToString();
            AudioPlay.Open(new Uri(PlayingFile));
            AudioPlay.Play();
            MusicCover.Visibility = Visibility.Visible;
            PlayAudio.Visibility = Visibility.Visible;
            PauseAudio.Visibility = Visibility.Visible;
            StopAudio.Visibility = Visibility.Visible;
            NameOfAudio.Visibility = Visibility.Visible;
            NameOfAudio.Text = NameOfSong;
        }
        private void Backward_Click(object sender, RoutedEventArgs e)
        {
            if (PlayListIndex > 0)
            {
                PlayListIndex = PlayListIndex - 1;
            }
            else
            {
                PlayListIndex = ListOfSongs.Items.Count - 1;
            }
            PlayingFile = ListOfPaths.Items.GetItemAt(PlayListIndex).ToString();
            NameOfSong = ListOfSongs.Items.GetItemAt(PlayListIndex).ToString();
            AudioPlay.Open(new Uri(PlayingFile));
            AudioPlay.Play();
            NameOfAudio.Text = NameOfSong;
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            if (PlayListIndex < (ListOfSongs.Items.Count - 1))
            {
                PlayListIndex += 1;
            }
            else
            {
                PlayListIndex = 0;
            }
            PlayingFile = ListOfPaths.Items.GetItemAt(PlayListIndex).ToString();
            NameOfSong = ListOfSongs.Items.GetItemAt(PlayListIndex).ToString();
            AudioPlay.Open(new Uri(PlayingFile));
            AudioPlay.Play();
            NameOfAudio.Text = NameOfSong;
        }
        private void SavePlaylist_Click(object sender, RoutedEventArgs e)
        {
            string[] s = new string[ListOfSongs.Items.Count];
            string[] p = new string[ListOfPaths.Items.Count];
            File.WriteAllText(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\IsPlaylistCreated.txt", "true");
            for (int i = 0; i < ListOfSongs.Items.Count; i++)
            {
                s[i] = ListOfSongs.Items.GetItemAt(i).ToString();
                p[i] = ListOfPaths.Items.GetItemAt(i).ToString();
            }
            File.WriteAllLines(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PlayListSaver.txt", s);
            File.WriteAllLines(@"C:\Users\angry\OneDrive\Рабочий стол\ТПП\лр6\AudioPlayer\PathSaver.txt", p);
        }
    }
}
