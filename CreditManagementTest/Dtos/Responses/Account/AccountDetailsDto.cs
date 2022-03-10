using System;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.User;

namespace CreditManagementTest.Dtos.Responses.Account
{
    public class AccountDetailsDto : SuccessResponse
    {
        public long Id { get; set; }
        public string AccountName { get; set; }
        
        public UserBasicEmbeddedInfoDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }

        public static AccountDetailsDto Build(Entities.Account account, bool includeUser = false)
        {
            var dto = new AccountDetailsDto
            {
                Id = account.Id,
                AccountName = account.AccountName,
                CreatedAt = account.CreatedAt,
                UpdatedAt = account.UpdatedAt
            };

            if (includeUser)
            {
                dto.User = UserBasicEmbeddedInfoDto.Build(account.User);
            }

            return dto;
        }
    }
}