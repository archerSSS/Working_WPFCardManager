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

namespace CardManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OT.Visibility == Visibility.Hidden)
            {
                DT.IsEnabled = false;
                DT.Visibility = Visibility.Hidden;
                OT.IsEnabled = true;
                OT.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DT.Visibility == Visibility.Hidden)
            {
                OT.IsEnabled = false;
                OT.Visibility = Visibility.Hidden;
                DT.IsEnabled = true;
                DT.Visibility = Visibility.Visible;
            }
        }
    }
}
