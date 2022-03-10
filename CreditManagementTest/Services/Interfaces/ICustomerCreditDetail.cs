using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.CreditDetail;
using CreditManagementTest.Entities;

namespace CreditManagementTest.Services.Interfaces
{
    public interface ICustomerCreditDetail
    {
        Task<CustomerCreditDetail> CreateAsync(ApplicationUser user, CreateOrEditCreditDetailDto dto, long userId);

        Task<CustomerCreditDetail> GetByUserAsync(long userId);

        Task<int> UpdateAsync(CustomerCreditDetail customerCreditDetail, CreateOrEditCreditDetailDto dto);
    }
}