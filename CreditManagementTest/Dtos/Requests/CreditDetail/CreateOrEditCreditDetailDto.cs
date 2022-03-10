using Newtonsoft.Json;

namespace CreditManagementTest.Dtos.Requests.CreditDetail
{
    public class CreateOrEditCreditDetailDto
    {
        public int Limit { get; set; }        
        
        public int Term { get; set; }
    }
}