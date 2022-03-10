using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.Account;
using CreditManagementTest.Entities;

namespace CreditManagementTest.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAsync(ApplicationUser user, CreateOrEditAccountDto dto, long userId);

        Task<Tuple<int, List<Account>>> FetchPageByUser(ApplicationUser user, int page, int pageSize);

        Task<Account> FetchByName(string name); 
        Task<int> UpdateAsync(Account account, CreateOrEditAccountDto dto);
    }
}