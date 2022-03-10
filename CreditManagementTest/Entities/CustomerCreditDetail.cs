using System;
using System.Collections.Generic;

namespace CreditManagementTest.Entities
{
    public class CustomerCreditDetail
    {
        public CustomerCreditDetail()
        {
            //CreatedAt = DateTime.Now;
        }

        public long Id { get; set; }
        public int Limit { get; set; }
        public int Term { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        public ApplicationUser User { get; set; }
        public long? UserId { get; set; }


        public string RenderContent()
        {
            throw new NotImplementedException();
        } 
    }
}