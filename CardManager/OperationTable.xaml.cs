using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для OperationTable.xaml
    /// </summary>
    public partial class OperationTable : UserControl
    {
        private static readonly Regex regex = new Regex("[^0-9.-]+");

        public OperationTable()
        {
            InitializeComponent();
            FilteredOperations = new ObservableCollection<FilteredOperation>();
        }





        ObservableCollection<FilteredOperation> FilteredOperations
        {
            get { return (ObservableCollection<FilteredOperation>)GetValue(FilteredOperationsProperty); }
            set { SetValue(FilteredOperationsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilteredOperations.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilteredOperationsProperty =
            DependencyProperty.Register("FilteredOperations", typeof(ObservableCollection<FilteredOperation>), typeof(OperationTable), new PropertyMetadata());




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal price = Decimal.Parse(TextPrice.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
            int count = -1;
            try
            {
                count = Int32.Parse(TextCount.Text);
            }
            catch (Exception ex)
            {
            }

            object em = ComboEmployers.SelectedItem;
            object ca = ComboCards.SelectedItem;
            DateTime? da = CalendarDate.SelectedDate;
            if (em != null && ca != null && da != null && count != -1)
            {
                ViewModel VM = (ViewModel)DataContext;
                VM.AddOperation(da, em, ca, price, count);
                MessageBox.Show("Операция добавлена");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            decimal price = 0;
            string employer = "";
            string card = "";
            DateTime db;
            DateTime de;

            if (CalendarBegin.SelectedDate == null || CalendarEnd.SelectedDate == null) return;
            db = CalendarBegin.SelectedDate.Value;
            de = CalendarEnd.SelectedDate.Value;

            if (TextFilterPrice.Text != "")
            {
                try
                {
                    price = Decimal.Parse(TextFilterPrice.Text, NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                }
            }

            if (ComboFilterCards.SelectedItem != null) card = (string)ComboFilterCards.SelectedItem;
            if (ComboFilterEmployers.SelectedItem != null) employer = (string)ComboFilterEmployers.SelectedItem;

            ViewModel VM = (ViewModel)DataContext;
            FilteredOperations = VM.GetOperations(db, de, employer, card, price);
        }

        private void TextPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }
    }
}
