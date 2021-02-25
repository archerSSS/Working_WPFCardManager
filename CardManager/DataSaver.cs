using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CardManager
{
    class DataSaver
    {
        public void SaveOperations(ObservableCollection<Operation> operations)
        {
            try
            {
                using (Stream stream = new FileStream("op.data", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, operations);
                }
            }
            catch (Exception e)
            {

            }
        }

        public void SaveCards(ObservableCollection<string> cards)
        {
            try
            {
                using (Stream stream = new FileStream("ca.data", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, cards);
                }
            }
            catch (Exception e)
            {

            }
        }

        public void SaveEmployers(ObservableCollection<string> employers)
        {
            try
            {
                using (Stream stream = new FileStream("em.data", FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, employers);
                }
            }
            catch (Exception e)
            {

            }
        }

        public ObservableCollection<Operation> LoadOperations()
        {
            ObservableCollection<Operation> operations = new ObservableCollection<Operation>();
            try
            {
                using (Stream stream = new FileStream("op.data", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    operations = (ObservableCollection<Operation>)bf.Deserialize(stream);
                }
            }
            catch (Exception e)
            {

            }
            return operations;
        }

        public ObservableCollection<string> LoadCards()
        {
            ObservableCollection<string> cards = new ObservableCollection<string>();
            try
            {
                using (Stream stream = new FileStream("ca.data", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    cards = (ObservableCollection<string>)bf.Deserialize(stream);
                }
            }
            catch (Exception e)
            {

            }

            return cards;
        }

        public ObservableCollection<string> LoadEmployers()
        {
            ObservableCollection<string> employers = new ObservableCollection<string>();
            try
            {
                using (Stream stream = new FileStream("em.data", FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    employers = (ObservableCollection<string>)bf.Deserialize(stream);
                }
            }
            catch (Exception e)
            {

            }

            return employers;
        }
    }
}
