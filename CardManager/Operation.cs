using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManager
{
    [Serializable]
    class Operation : INotifyPropertyChanged
    {
        private DateTime date;
        private string name;
        private string cardType;
        private int count;
        private decimal price;

        public DateTime Date { get { return date; } set { date = value; OnPropertyChanged("Date"); } }
        public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
        public string CardType { get { return cardType; } set { cardType = value; OnPropertyChanged("CardType"); } }
        public int Count { get { return count; } set { count = value; OnPropertyChanged("Count"); } }
        public decimal Price { get { return price; } set { price = value; OnPropertyChanged("Price"); } }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string pn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pn));
            }
        }
    }
}
