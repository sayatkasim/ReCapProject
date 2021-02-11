using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton== MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                tt_list.Visibility = Visibility.Collapsed;
                tt_add.Visibility = Visibility.Collapsed;
                tt_delete.Visibility = Visibility.Collapsed;
                tt_update.Visibility = Visibility.Collapsed;
                tt_user.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_add.Visibility = Visibility.Visible;
                tt_list.Visibility = Visibility.Visible;
                tt_delete.Visibility = Visibility.Visible;
                tt_update.Visibility = Visibility.Visible;
                tt_user.Visibility = Visibility.Visible;
            }
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
