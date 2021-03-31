using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Greeting.Repository
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }
    public class CustomerContent
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string Email { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public CustomerContent() { }
        public CustomerContent(string firstName, string lastName, CustomerType typeOfCustomer, string email, string fullName)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
            Email = email;


        }
    }
}
