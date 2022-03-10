using System.ComponentModel.DataAnnotations;

namespace CreditManagementTest.Dtos.Responses.CustomerCreditDetail
{
    public class CreateCustomerCreditDetailDto
    {
        public long Id { get; set; }
        
        [Required] public string Content { get; set; } 
    }
}