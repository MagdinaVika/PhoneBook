using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static int id = 1;
        static Dictionary<int, string> NamesDict = new Dictionary<int, string>();
        static Dictionary<int, List<string>> PhonesDict = new Dictionary<int, List<string>>();
        static Dictionary<int, List<string>> OtherDict = new Dictionary<int, List<string>>();

        static void Main(string[] args)
        {
            
            addNewContact("Vanya Pupkin");
            addPhoneToContact("Vanya Pupkin", "12312312");
            addPhoneToContact("Vanya Pupkin", "123123123");
            addPhoneToContact("Vanya Pupkin", "123123123123");
            addPhoneToContact("Vanya Pupkin", "12312313123");
            addPhoneToContact("Vanya Pupkin", "0000123123");
            otherDataToContact("Vanya Pupkin", "pupkin@gmail.com");
            otherDataToContact("Vanya Pupkin", "skype:kuku_shnyaga");

            addNewContact("Alyosha");
            addPhoneToContact("Alyosha", "72312312");
            addPhoneToContact("Alyosha", "723123123");
            addPhoneToContact("Alyosha", "723123123123");
            addPhoneToContact("Alyosha", "72312313123");
            addPhoneToContact("Alyosha", "0776123123");
            otherDataToContact("Alyosha", "leha@gmail.com");
            otherDataToContact("Alyosha", "skype:kozlina");

            showContact("Vanya Pupkin");
            showContact("Alyosha");

            RemoveContact("Vanya Pupkin");
            showContact("Vanya Pupkin");

            Console.ReadLine();
        }

        private static void addPhoneToContact(string Name, string phone)
        {
            int currentRecord = findFirstIdByValue(Name);
            if (currentRecord <= 0) return;
            List<string> phones;
            PhonesDict.TryGetValue(currentRecord, out phones);
            phones.Add(phone);
            PhonesDict[currentRecord] = phones;
        }
        private static void otherDataToContact(string Name, string data)
        {
            int currentRecord = findFirstIdByValue(Name);
            if (currentRecord <= 0) return;
            List<string> others;
            OtherDict.TryGetValue(currentRecord, out others);
            others.Add(data);
            OtherDict[currentRecord] = others;
        }

        private static void showContact(string v)
        {
            if (NamesDict.ContainsValue(v))
            {
                string Name;
                int ID = findFirstIdByValue(v);

                NamesDict.TryGetValue(ID, out Name);
                Console.WriteLine("Name: {0}", Name);
                Console.Write("Phones: ");
                List<string> phones;
                PhonesDict.TryGetValue(ID, out phones);
                for (int i = 0; i < phones.Count; i++)
                {
                    Console.Write(phones[i] + " ");
                }
                Console.Write("\n");
                Console.Write("Other Data: ");
                List<string> others;
                OtherDict.TryGetValue(ID, out others);
                for (int i = 0; i < others.Count; i++)
                {
                    Console.Write(others[i] + " ");
                }
                Console.Write("\n");
            }
        }
        private static int findFirstIdByValue(string v)
        {
            if (NamesDict.ContainsValue(v))
            {
               Dictionary<int,string>.Enumerator enumerator = NamesDict.GetEnumerator();
                enumerator.MoveNext();
                for (int i = 0; i < NamesDict.Count; i++)
                {
                    if (enumerator.Current.Value.Equals(v)) return enumerator.Current.Key;
                    else {
                        enumerator.MoveNext();
                    }
                }
            }
            return 0;
        }

        private static void addNewContact(string Name)
        {
            NamesDict.Add(id, Name);
            PhonesDict.Add(id, new List<string>());
            OtherDict.Add(id, new List<string>());
            id++;
        }
        private static void RemoveContact(string Name)
        {
            int ID = findFirstIdByValue(Name);
            if (ID > 0)
            {
                NamesDict.Remove(ID);
                PhonesDict.Remove(ID);
                OtherDict.Remove(ID);
            }

        }

    }
}
