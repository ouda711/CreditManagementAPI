using System;

namespace CreditManagementTest.Entities
{
    public class Invoice
    {
       public long Id { get; set; }
       public DateTime DueDate { get; set; }
       public int Amount { get; set; }

       public string Status { get; set; } = "pending";
       public DateTime CreatedAt { get; set;} = DateTime.Now;
       public DateTime UpdatedAt { get; set; }
       
       public ApplicationUser User { get; set; }
       public long UserId { get; set; }
       
       public Account Account { get; set; }
       public long AccountId { get; set; }
    }
}