using System;
using System.Collections.Generic;
using System.Data.Common; 
using System.Linq;
using System.Text;

namespace PhoneBookApp
{
    public class UserInt :Contacts
    {

        /// <summary>
        /// Writes the program greeting
        /// </summary>
        public void OpenBook()
        {
            Console.WriteLine("Welcome to the last phone book you\'ll ever need!");
            Console.WriteLine("What would you like to do?");
        }
        
        /// <summary>
        /// Writes menu listed as string for user interface
        /// </summary>
        public void OpenMenu()//Display user options
        {
           Console.WriteLine("\n\n 1: Create a contact.\n " +
               "2: Update a contact. \n 3: View contacts\n" +
               " 4: Delete contacts.\n 5: Exit..");
            
            

        }
        
        /// <summary>
        /// This method is the main program operation built in to a switch that at the end of each 
        /// case will call the OpenMenu and then itsself to loop back to menu and user selection
        /// </summary>
        public void UserSelected() // Build user experience for all options using a switch statement
        {
            string userAnswer = Console.ReadLine();
            switch (userAnswer)
            {
                case "1":
                    AddContact();
                    
                   // Creating a functional loop to continue program runtime until user selects End with chained methods
                    OpenMenu();
                    UserSelected();
                    break;
                case "2":
                        UpdateContact();
                    
                        OpenMenu();
                        UserSelected();
                           
                    break;

                case "3":
                    DisplayContact();

                    OpenMenu();
                    UserSelected();
                    break;
                case "4":

                    DeleteConatact();


                    OpenMenu();
                    UserSelected();
                    break;

                case "5":

                    ExitDoor();
                    break;


            }
        }
    }
}
