using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Account
{
    public class AccountListDto : SuccessResponse
    {
        public PageMeta PageMeta { get; set; }
        public ICollection<AccountDetailsDto> Accounts { get; set; }

        public static AccountListDto Build(ICollection<Entities.Account> accounts, string basePath, int currentPage,
            int pageSize, int totalItemCount)
        {
            ICollection<AccountDetailsDto> result = new List<AccountDetailsDto>();
            foreach (var account in accounts)
            {
                result.Add(AccountDetailsDto.Build(account, true));
            }

            return new AccountListDto
            {
                Success = true,
                PageMeta = new PageMeta(result.Count, basePath, currentPageNumber: currentPage,
                    requestedPageSize: pageSize, totalItemCount: totalItemCount),
                Accounts = result
            };
        }
    }
}