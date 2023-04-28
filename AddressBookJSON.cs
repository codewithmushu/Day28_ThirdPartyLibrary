using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace AddressBook_ThirdPartyLibrary
{
    public class AddressBookJSON
    {
        private List<Person> contacts = new List<Person>();

        public void ReadContacts(string filepath)
        {
            try
            {
                string json = File.ReadAllText(filepath);

                contacts = JsonConvert.DeserializeObject<List<Person>>(json);


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading contacts from file : " + ex.Message);
            }
        }

        public void WriteContacts(string filepath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(contacts);

                File.WriteAllText(filepath, json);

                Console.WriteLine("Contacts Written to file successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Writing contacts to file : " + ex.Message);
            }
        }

        public void AddContact(Person person)
        {
            contacts.Add(person);
            Console.WriteLine("Contact added successfully.");
        }

        public void DisplayContacts()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine("Name\t\tEmail\t\t\tPhone");

                foreach (Person person in contacts)
                {
                    Console.WriteLine(person.Name + "\t\t" + person.Email + "\t" + person.Phone);
                }
            }
        }
    }
}
