using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookApp
{
    public class Contacts
        /// <summary>
        /// Base Class, contains dictionary and properties of a contact
        /// as well as contructors(default and parameterized) and lastly a contact formatting method
        /// </summary>
        
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }


        //dictionary created to store Contacts
        /// <summary>
        /// This dictionary will contain all user input with the key being set to Contacts.PhoneNumber
        /// and the Value being set to a formatted string using instance of class Contacts and the parameters
        /// </summary>



        public int _counter = 1;
        public Contacts()
        {
            
        }

        public Dictionary<int,Contacts>  contactDict = new Dictionary<int, Contacts>();


        /// <summary>
        /// Parameterized Constructor that will create a new instance of Contacts class
        /// </summary>
        /// <param name="firstName">Contacts.FirstName</param>
        /// <param name="lastName">Contacts.LastName</param>
        /// <param name="address">Contacts.Address</param>
        /// <param name="phoneNumber">Contacts.PhoneNumber</param>
        /// <param name="dateOfBirth">Contacts.DateOfBirth</param>
        //parameterized constructor
        public Contacts(string firstName, string lastName, string address, string phoneNumber, string dateOfBirth)
        {


            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;

           



        }
        /// <summary>
        /// This method operates the sole purpose of taking the contact information provided by the user and returning the format that lists Contacs
        /// in a format that is easy to read in a string that is then stored to contactDict
        /// </summary>
        /// <param name="first">Takes Contact.FirstName</param>
        /// <param name="last">Takes Contact.LastName</param>
        /// <param name="add">Takes Contact.Address</param>
        /// <param name="phone">Takes Contact.PhoneNumber</param>
        /// <param name="bday">Takes Contact.DateOfBirth</param>
        /// <returns></returns>
        public string ContactFormat(Contacts contact)
        {
            string answer = $"Full name: {contact.FirstName} {contact.LastName}\nPhone number: " +
                $"{contact.PhoneNumber}\nAddress: {contact.Address}\nBirthday: {contact.DateOfBirth}";

            //returns formatted contactDict string fo user interface
            return answer;
        }
        /// <summary>
        /// Method to intialize class object and assign vaules with user input
        /// then convert object into a formatted string and add to contactDict
        /// </summary>
        public void AddContact()
        {
            //Will ask for specific user input, assign to a variable and use variable to run constructor Contact, create an instance of
            //contact class and add it to a dictionary with the key value pair being phone number : Contact
            Contacts newContact = new Contacts();

       

        Console.WriteLine("Please enter a first name:");
            newContact.FirstName = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Please enter a last name:");
            newContact.LastName = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Please enter an address:");
            newContact.Address = Console.ReadLine();
            Console.WriteLine();


            Console.WriteLine("Please enter a phone number:");
            newContact.PhoneNumber = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter a date of birth:");
            newContact.DateOfBirth = Console.ReadLine();


            contactDict.Add(_counter, newContact);
            _counter++;
            WriteItOut();
        Console.WriteLine("This contact has been added!\n\n Press enter to return to the menu:");
            Console.ReadLine();
            //CreateContact();
           
        }
        /// <summary>
        /// Method shows contacts as reference point to select contact to update
        /// validates correct contact with user, then allows user to replace information and removes old information
        /// </summary>
        public void UpdateContact()
        {
            //Stars by letting the user examine already entered contacts so that user can reference 
            //to search by number 
            Console.WriteLine("Lets decide who you would like to update");
            foreach (KeyValuePair<int,Contacts> val in contactDict)
            {
                Console.WriteLine($"\n\n{val.Key }:\n {ContactFormat(val.Value)}\n\n");
                // thread.sleep(3000)
            }
            

            //search for contact in contactDict by key
            Console.WriteLine("Please select a contact by number:");
            var conSel = int.Parse(Console.ReadLine());//user input number

            //uses conditional to determine matching key to user input
            if (contactDict.ContainsKey(conSel) == true)
            {
                //adds a validation point to update interaction
                Console.WriteLine(contactDict[conSel]);
                Console.WriteLine("\nIs this the correct contact? y/n");
                var yOrN = Console.ReadLine();

                //nested coditional to ensure user experience with validation
                if (yOrN == "y")
                {
                    Contacts upContact = new Contacts();
                    //allows user to enter new contact info
                    Console.WriteLine("Please enter new contact details:");
                    Console.WriteLine();
                    Console.WriteLine("First Name:");
                    upContact.FirstName = Console.ReadLine();
                    Console.WriteLine();


                    Console.WriteLine("Last Name:");
                    upContact.LastName = Console.ReadLine();
                    Console.WriteLine();


                    Console.WriteLine("Address:");
                    upContact.Address = Console.ReadLine();
                    Console.WriteLine();


                    Console.WriteLine("Phone Number:");
                    upContact.PhoneNumber = Console.ReadLine();
                    Console.WriteLine();


                    Console.WriteLine("Birthday:");
                    upContact.DateOfBirth = Console.ReadLine();
                    Console.WriteLine();


                    contactDict.Remove(conSel);//uses .Remove to remove pre existing instance of the contact
                                               //contactDict.Add(newContact.PhoneNumber , newContact);
                                               //adds contact with new info to contactdict
                    contactDict.Add(_counter,upContact);
                    _counter++;
                    //WriteItOut();

                    Console.WriteLine("Contact Updated..");
                    Console.WriteLine();
                    Console.WriteLine("Press enter to return to the menu");
                    Console.ReadLine();
                    //exits conditional to OpenMenu and Userselectd
                }
                else
                {
                    // exits to chained methods
                    Console.WriteLine("Please try again or select another option:");

                }
            }
            else
            {
                //Provides user experience and instruction, exits conditional to Menu as this option is not valid
                Console.WriteLine("That contact doesnt appear to exist, please select option 1 to add them.");
            }
        }
        /// <summary>
        /// Mathod uses foreach to display all the values in contactDict
        /// </summary>
        public void DisplayContact()
        {
            //displays all user contacts on case being met, then directs user back to the menu


            //foreach (KeyValuePair<string, string> val in contactDict)
            //{
            //    Console.WriteLine($"\n\n{val.Value}\n\n");
            //ReadItOut();

            Console.WriteLine();
            Console.WriteLine("Press enter to open menu:");
            Console.ReadLine();

        }
        /// <summary>
        /// Uses .ContainsKey to search by key and then .Remove to remove the key value pair
        /// </summary>
        public void DeleteConatact()
        {

            //Delete contact section allows user ro search by key, and deletes the value and key from contactDict using .Remove 
            Console.WriteLine("Search the contacts by number:");
            var searchTerm = int.Parse(Console.ReadLine());
            if (contactDict.ContainsKey(searchTerm) == true)
            {

                contactDict.Remove(searchTerm);//Adds user experience with message and readline 
                Console.WriteLine("This contact has been deleted.\n\n Press Enter to continue to the menu:");
                Console.ReadLine();

            }
            else
            {
                //redirects failed search to menu
                Console.WriteLine("That contact does not exist!\n\n Please press enter to return to the menu:");
                Console.ReadLine();
            }
        }
        /// <summary>
        /// Exits program on user selection with goodbye message
        /// </summary>
        public void ExitDoor()
        {
            //exit program
            Console.WriteLine();
            Console.Write("Thanks for using the last phonebook you\'ll ever need!" +
                "\n\n Have a great day!\n\n\n Press enter to exit: ");
            Console.ReadLine();
            

        }
        public void WriteItOut()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter sw = new StreamWriter(@"C:\Users\mbfla\source\repos\PhoneBookAppsln\PhoneBookApp\bin\Debug\netcoreapp3.1\WriteLines.txt")) 
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, contactDict.Values);
            }

            
            



        }
        public void ReadItOut()
        {


        }
        //public static void CreateContact()
        //{
        //    //Will ask for specific user input, assign to a variable and use variable to run constructor Contact, create an instance of 
        //    //contact class and add it to a dictionary with the key value pair being phone number : Contact
        //    Contacts newContact = new Contacts();

        //    Console.WriteLine("Please enter a first name:");
        //    newContact.FirstName = Console.ReadLine();
        //    Console.WriteLine();


        //    Console.WriteLine("Please enter a last name:");
        //    newContact.LastName = Console.ReadLine();
        //    Console.WriteLine();


        //    Console.WriteLine("Please enter an address:");
        //    newContact.Address = Console.ReadLine();
        //    Console.WriteLine();


        //    Console.WriteLine("Please enter a phone number:");
        //    newContact.PhoneNumber = Console.ReadLine();
        //    Console.WriteLine();

        //    Console.WriteLine("Please enter a date of birth:");
        //    newContact.DateOfBirth = Console.ReadLine();


        //    contactDict.Add(_counter, newContact);
        //    _counter++;
        //    WriteItOut();
        //    Console.WriteLine("This contact has been added!\n\n Press enter to return to the menu:");
        //    Console.ReadLine();
        //}

    }
}
