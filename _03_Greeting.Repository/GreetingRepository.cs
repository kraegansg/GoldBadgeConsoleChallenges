using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Greeting.Repository
{
    public class GreetingRepository
    {
        private List<CustomerContent> _listOfContent = new List<CustomerContent>();

        //Create
        public bool AddContentToList(CustomerContent content)
        {
            int startingCount = _listOfContent.Count;
            _listOfContent.Add(content);
            bool wasAdded = (_listOfContent.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<CustomerContent> GetContentList()
        {
            return _listOfContent;
        }

        // Update
        public bool UpdateCustomerContent(string originalName, CustomerContent newContent)
        {
            CustomerContent oldContent = GetCustomerByName(originalName);

            if (oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.TypeOfCustomer = newContent.TypeOfCustomer;
                oldContent.Email = newContent.Email;

                return true;
            }
            else
            {
                return false;
            }
            
        }

        // Delete
        public bool RemoveGreetingContent(string fullName)
        {
            CustomerContent content = GetCustomerByName(fullName);

            if (content == null)
            {
                return false;
            }

            int initialCount = _listOfContent.Count;
            _listOfContent.Remove(content);

            if (initialCount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Search method
        public CustomerContent GetCustomerByName(string fullName)
        {
            foreach (CustomerContent content in _listOfContent)
            {
                if (content.FullName.ToLower() == fullName.ToLower())
                {
                    return content;
                }
            }

            return null;
        }
    }
}
