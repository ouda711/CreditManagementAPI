using System;
using System.Collections.ObjectModel;

namespace CreditManagementTest.Entities
{
    public class Account
    {
       public Account(){}
       
       public long Id { get; set; }
       public string AccountName { get; set; }
       
       public DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
       
       public ApplicationUser User { get; set; }
       public long UserId { get; set; }

       public Collection<Invoice> Invoices { get; set; }
       
       public string RenderContent()
       {
           throw new NotImplementedException();
       }
    }
}