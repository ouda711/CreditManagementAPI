using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Bogus;
using CreditManagementTest.Data;
using CreditManagementTest.Dtos.Requests.CreditDetail;
using CreditManagementTest.Entities;
using CreditManagementTest.Models;
using CreditManagementTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementTest.Services
{
    public class CustomerCreditDetailService : ICustomerCreditDetail
    {
        private readonly ApplicationDbContext _context;
        private readonly HtmlEncoder _htmlEncoder;

        public CustomerCreditDetailService(ApplicationDbContext context, HtmlEncoder htmlEncoder)
        {
            _context = context;
            _htmlEncoder = htmlEncoder;
        }
        
        public async Task<CustomerCreditDetail> CreateAsync(ApplicationUser user, CreateOrEditCreditDetailDto dto, long userId)
        {
            var customerDetail = new CustomerCreditDetail()
            {
                Limit = dto.Limit,
                Term = dto.Term,
                UserId = userId,
                User = user,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _context.CustomerCreditDetails.AddAsync(customerDetail);
            await _context.SaveChangesAsync();
            return customerDetail;
        }

        public async Task<CustomerCreditDetail> GetByUserAsync(long userId)
        {
            return await _context.CustomerCreditDetails.Include(c => c.User).FirstOrDefaultAsync(c=>c.UserId == userId);
        }


        private async Task<Tuple<int, List<CustomerCreditDetail>>> FetchPageFromQueryable(IQueryable<CustomerCreditDetail> queryable, int page,
            int pageSize)
        {
            var count = await queryable.CountAsync();
            var addresses = await queryable.Skip((page - 1) * pageSize).Take(pageSize)
                .Include(a => a.User)
                .ToListAsync();

            return await Task.FromResult(Tuple.Create(count, addresses));
        }
        public async Task<int> UpdateAsync(CustomerCreditDetail customerCreditDetail, CreateOrEditCreditDetailDto dto)
        {
            customerCreditDetail.Term = dto.Term;
            customerCreditDetail.Limit = dto.Limit;
            return await _context.SaveChangesAsync();
        }
    }
}