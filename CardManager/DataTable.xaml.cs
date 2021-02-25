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
    /// Логика взаимодействия для DataTable.xaml
    /// </summary>
    public partial class DataTable : UserControl
    {
        public DataTable()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = TextEmployer.Text;
            if (name != "")
            {
                ViewModel VM = (ViewModel)DataContext;
                VM.AddEmployer(name);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string card = TextCard.Text;
            if (card != "")
            {
                ViewModel VM = (ViewModel)DataContext;
                VM.AddCardType(card);
            }
        }
    }
}
