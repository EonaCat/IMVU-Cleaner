using NightBits_IMVU_Cleaner.ViewModels;
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

namespace NightBits_IMVU_Cleaner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _mainViewModel = new MainViewModel();
        private String _action;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CleanAll_Click(object sender, RoutedEventArgs e)
        {
            if (KillImvu())
            {
                _action = "log, cache and avi";
                _mainViewModel.CleanCache();
                _mainViewModel.CleanLogs();
                _mainViewModel.CleanAvi();
                ShowInformation();
            }
        }

        private void CleanLogs_Click(object sender, RoutedEventArgs e)
        {
            if (KillImvu())
            {
                _action = "log";
                _mainViewModel.CleanLogs();
                ShowInformation();
            }
        }

        private void CleanCache_Click(object sender, RoutedEventArgs e)
        {
            if (KillImvu())
            {
                _action = "cache";
                _mainViewModel.CleanCache();
                ShowInformation();
            }            
        }

        private void CleanAvi_Click(object sender, RoutedEventArgs e)
        {
            if (KillImvu())
            {
                _action = "avi";
                _mainViewModel.CleanAvi();
                ShowInformation();
            }
        }

        private void ShowInformation()
        {
            MessageBox.Show(String.Format("The IMVU {0} files have been removed." + Environment.NewLine + "You can now start IMVU again." + Environment.NewLine + "This program has been created by Jeroen Saey (NightBits)",_action),"Done");
        }

        private bool KillImvu()
        {
            if (_mainViewModel.isRunning())
            {
                if (MessageBox.Show("IMVU will be closed are you sure?", "Close IMVU", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return false;
                }
                else
                {
                    _mainViewModel.KillImvu();
                }
            }
            return true;
        }
    }
}
