using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.Repository
{
    public class ClaimsRepository
    {
        public Queue<ClaimsContent> _queueOfContent = new Queue<ClaimsContent>();

        // View all claims method 
        public Queue<ClaimsContent> GetClaimsContent()
        {
            return _queueOfContent;
        }


        // Add new claim to queue method
        public void AddContentToQueue(ClaimsContent content)
        {
            _queueOfContent.Enqueue(content);
        }

        // remove claim from queue method 

        public void RemoveClaim(int claimToDelete)
        {
            _queueOfContent.Dequeue();
        }

         // helper method // Unit Test Search Function
        public ClaimsContent GetContentByID(int claim)
        {
            foreach (ClaimsContent content in _queueOfContent)
            {
                if (content.ClaimID == claim)
                {
                    return content;
                }
            }
            return null;

        }

    }
}
