using System;
using System.Collections;

namespace CSFundamentals.Concepts.HashTables
{
    public class PhoneBook
    {
        public PhoneBook()
        {
        }

        public void PhoneBookWorker()
        {
            // Instatiating and assigning a Hashtable
            var phoneBook = new Hashtable()
            {
                {"Marcin Jamro", "000-000-0000" },
                {"John Smith", "111-111-1111" }
            };
            phoneBook["Lily Smith"] = "333-333-3333";

            // Using the Add function to add a record to the Hashtable
            try
            {
                phoneBook.Add("Mary Fox", "222-222-2222");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entry already exist!");
            }

            // Iterating through the Hashtable
            Console.WriteLine("Phone Numbers:");
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Empty!");
            }
            else
            {
                foreach(DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($" - {entry.Key}: {entry.Value}");
                }
            }

            // Check is a key exists
            Console.WriteLine();
            Console.WriteLine("Search by name:");
            var name = Console.ReadLine();
            if (phoneBook.Contains(name))
            {
                Console.WriteLine($"Found phone number: {(string)phoneBook[name]}");
            }
            else
            {
                Console.WriteLine("The entry does not exist");
            }
        }
    }
}
