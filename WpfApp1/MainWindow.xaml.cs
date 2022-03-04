//using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
using WpfApp1.Scripts;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CheckAccess check = new CheckAccess();
        public MainWindow()
        {
            InitializeComponent();
        
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;

        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if(check.Role != "Admin")
            {
                
                MainFrame.Navigate(new System.Uri("DownloadPage.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("У вас нет доступа");
            }
           

        }

        private void Logout_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AuthorizButton_Click(object sender, RoutedEventArgs e)
        {
            if (check.AuthCheck == "Авторизирован")
            {
                MessageBox.Show("Вы уже авторизированы");

            }
            else
            {
                
                MainFrame.Navigate(new System.Uri("AuthorizePage.xaml", UriKind.RelativeOrAbsolute));

            }
           

        }

        private void Reports_click(object sender, RoutedEventArgs e)
        {
           
            if (check.Role != "Admin")
            {
               
                MainFrame.Navigate(new System.Uri("CheckingReports.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            {
                MessageBox.Show("У вас нет доступа");
            }
        }

        private void AddReport_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new System.Uri("AddReport.xaml", UriKind.RelativeOrAbsolute));

        }
    }

   
}

