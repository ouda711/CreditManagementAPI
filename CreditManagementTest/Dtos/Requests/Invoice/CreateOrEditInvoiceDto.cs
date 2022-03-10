using System;

namespace CreditManagementTest.Dtos.Requests.Invoice
{
    public class CreateOrEditInvoiceDto
    {
       public int Amount { get; set; }
       public DateTime DueDate { get; set; }
    }
}