using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardManager
{
    class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> employers;
        private ObservableCollection<string> cards;
        private ObservableCollection<Operation> operations;
        private DataSaver saver;

        public ObservableCollection<string> Employers { get { return employers; } set { employers = value; OnPropertyChanged("Employers"); } }
        public ObservableCollection<string> Cards { get { return cards; } set { cards = value; OnPropertyChanged("Cards"); } }
        public ObservableCollection<Operation> Operations { get { return operations; } set { operations = value; OnPropertyChanged("Operations"); } }

        public ViewModel()
        {
            saver = new DataSaver();
            Employers = saver.LoadEmployers();
            Cards = saver.LoadCards();
            Operations = saver.LoadOperations();
        }

        public void AddEmployer(string name)
        {
            Employers.Add(name);
            saver.SaveEmployers(Employers);
        }

        public void AddCardType(string card)
        {
            Cards.Add(card);
            saver.SaveCards(Cards);
        }

        public void AddOperation(DateTime? date, object e, object c, decimal price, int count)
        {
            Operation o = new Operation() { Date = date.Value, Name = (string)e, CardType = (string)c, Price = price, Count = count };
            Operations.Add(o);
            saver.SaveOperations(Operations);
        }

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
