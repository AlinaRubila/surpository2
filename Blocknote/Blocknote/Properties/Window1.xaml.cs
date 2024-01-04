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
using System.Windows.Shapes;

namespace Blocknote.Properties
{
    public partial class Window1 : Window
    {
        public bool Answer = true;
        private void CANCEL_OP_Click(object sender, RoutedEventArgs e)
        {
            Do_You_Want_Saving.Close();
        }
        private void YES_Click(object sender, RoutedEventArgs e)
        {
            Answer = true;
        }

        private void NO_Click(object sender, RoutedEventArgs e)
        {
            Answer = false;
        }
        public bool WhatAnswer
        {
            get{ return Answer; }
        }
    }
}
