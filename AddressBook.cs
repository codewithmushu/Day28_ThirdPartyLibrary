using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace AddressBook_ThirdPartyLibrary
{
    public class AddressBook
    {
       
        private List<Person> contacts = new List<Person> ();

        public List<Person> Contacts { get => contacts; }

        public void AddContact(Person person)
        {
            contacts.Add(person);
        }

        public void ReadContacts(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader,CultureInfo.InvariantCulture))
            {
               csv.Context.RegisterClassMap<PersonMap>();


                contacts = csv.GetRecords<Person>().ToList();
            }
        }

        public void WriteContacts(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PersonMap>();

                csv.WriteHeader<Person>();
                csv.NextRecord();

                csv.WriteRecords(contacts);
            }
        }
    }

    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Map(p => p.Name).Name("Name");
            Map(p => p.Email).Name("Email");
            Map(p => p.Phone).Name("Phone");
        }
    }
}
