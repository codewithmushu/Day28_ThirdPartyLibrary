using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_ThirdPartyLibrary
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();

            addressBook.AddContact(new Person { Name = "John Doe", Email = "john.doe@example.com", Phone = "555-1234" });
            addressBook.AddContact(new Person { Name = "Jane Smith", Email = "jane.smith@example.com", Phone = "555-5678" });

            string fileName = "contact.csv";
            string filePath = @"C:\Users\91997\source\repos\AddressBook_ThirdPartyLibrary\contact.csv";

            addressBook.WriteContacts(filePath + fileName);

            addressBook.ReadContacts(filePath + fileName);

            foreach (Person person in addressBook.Contacts)
            {
                System.Console.WriteLine(person.Name + " - " + person.Email + " - " + person.Phone);
            }
        }
    }
}
