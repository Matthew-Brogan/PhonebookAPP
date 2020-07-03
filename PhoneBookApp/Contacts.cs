using System.Collections.Generic;

namespace PhoneBookApp
{
    public class Contacts
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; }

        public Dictionary<string,string>  contactDict = new Dictionary<string, string>();
        

        
        

        public Contacts()
        {

        }
        public string Contact(string firstName, string lastName, string address, string phoneNumber, string dateOfBirth)
        {
            
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.DateOfBirth = dateOfBirth;

            
            
            
               
                string answer = $"First name: {this.FirstName}\nLast Name: {this.LastName}\nAddress:{this.Address}\n" +
                $"Phone Number: {this.PhoneNumber}\nBirthday: {this.DateOfBirth}";

                
                
          
            return answer;

            
            
        }

    }
}
