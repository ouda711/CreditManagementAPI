using System;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.User;

namespace CreditManagementTest.Dtos.Responses.CustomerCreditDetail
{
    public class CustomerDetailDto : SuccessResponse
    {
        public long Id { get; set; }
        public int Limit { get; set; }
        public int Term { get; set; }
        
        public UserBasicEmbeddedInfoDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static CustomerDetailDto Build(Entities.CustomerCreditDetail customerCreditDetail,
            bool includeUser = false)
        {
            var dto = new CustomerDetailDto
            {
                Id = customerCreditDetail.Id,
                Limit = customerCreditDetail.Limit,
                Term = customerCreditDetail.Term,
                CreatedAt = customerCreditDetail.CreatedAt,
                UpdatedAt = customerCreditDetail.UpdatedAt
                
            };

            if (includeUser)
                dto.User = UserBasicEmbeddedInfoDto.Build(customerCreditDetail.User);
            return dto;
        }
        
    }
}