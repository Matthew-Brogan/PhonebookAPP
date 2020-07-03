using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneBookApp
{
    public class UserInt :Contacts
    {
        public void OpenBook()
        {
            Console.WriteLine("Welcome to the last phone book you\'ll ever need!");
            Console.WriteLine("What would you like to do?");
        }
        
        public void OpenMenu()
        {
           Console.WriteLine("\n\n 1: Create a contact.\n " +
               "2: Update a contact. \n 3: View contacts\n" +
               " 4: Delete contacts.\n 5: Exit..");
            
            

        }
        
        public void UserSelected()
        {
            string userAnswer = Console.ReadLine();
            switch (userAnswer)
            {
                case "1":
                    Console.WriteLine("Please enter a first name:");
                    var first = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter a last name:");
                    var last = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter an address:");
                    var reside = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter a phone number:");
                    var number = Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Please enter a date of birth:");
                    var bday = Console.ReadLine();
                    Contact(first, last, reside, number, bday);
                    contactDict.Add(number, Contact(first,last, reside, number, bday));
                    OpenMenu();
                    UserSelected();
                    break;
                case "2":
                    Console.WriteLine("Lets decide who you would like to update");
                    foreach (KeyValuePair<string,string> pair in contactDict)
                    {
                        Console.WriteLine($"\n{pair.Key}\n{pair.Value}\n\n");
                    }
                    Console.WriteLine("Please select a contact by number:");
                    var conSel = Console.ReadLine();
                    if (contactDict.ContainsKey(conSel)==true)
                    {
                        Console.WriteLine("Please enter new contact details:");
                        Console.WriteLine();
                        Console.WriteLine("First Name:");
                        var newFirst = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Last Name:");
                        var newLast = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Address:");
                        var newAddress = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Phone Number:");
                        var newNumber = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Birthday:");
                        var weird = Console.ReadLine();
                        Console.WriteLine();
                        contactDict.Remove(conSel);

                        contactDict.Add(newNumber, Contact(newFirst, newLast, newAddress, newNumber, weird));
                        Console.WriteLine("Contact Updated..");
                        Console.WriteLine();
                      
                    }
                    else
                    {
                        Console.WriteLine("That contact doesnt appear to exist, please select option 1 to add them.");
                    }
                    
                        OpenMenu();
                        UserSelected();
                           
                    break;

                case "3":
                    Console.WriteLine("Okay.. Loading Contacts:");
                    foreach (KeyValuePair<string, string> val in contactDict)
                    {
                        Console.WriteLine($"\n{val.Value}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Whats next?");
                    OpenMenu();
                    UserSelected();
                    break;
                case "4":
                    Console.WriteLine("Search the contacts by phone number:");
                    var searchTerm = Console.ReadLine();
                    if (contactDict.ContainsKey(searchTerm)== true)
                    {
                        contactDict.Remove(searchTerm);
                        Console.WriteLine("This contact has been deleted.");

                    }
                    else
                    {
                        Console.WriteLine("That contact does not exist!");
                    }
                    OpenMenu();
                    UserSelected();
                    break;

                case "5":


                    Console.WriteLine();
                    Console.Write("Thanks for using the last phonebook you\'ll ever need!" +
                        "\n\n Have a great day!\n\n\n Press enter to exit: ");
                    Console.ReadLine();
                    break;


            }
        }
    }
}
