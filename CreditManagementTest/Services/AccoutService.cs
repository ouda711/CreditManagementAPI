using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CreditManagementTest.Data;
using CreditManagementTest.Dtos.Requests.Account;
using CreditManagementTest.Entities;
using CreditManagementTest.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CreditManagementTest.Services
{
    public class AccoutService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly HtmlEncoder _htmlEncoder;

        public AccoutService(ApplicationDbContext context, HtmlEncoder htmlEncoder)
        {
            _context = context;
            _htmlEncoder = htmlEncoder;
        }
        public async Task<Account> CreateAsync(ApplicationUser user, CreateOrEditAccountDto dto, long userId)
        {
            var account = new Account()
            {
                AccountName = _htmlEncoder.Encode(dto.AccountName),
                UserId = userId,
                User = user,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Tuple<int, List<Account>>> FetchPageByUser(ApplicationUser user, int page, int pageSize)
        {
            var count = _context.Accounts.Count(a => a.User.Id == user.Id);
            var queryable = _context.Accounts.Where(a => a.User == user)
                .Include(a => a.User);
            return await FetchPageFromQueryable(queryable, page, pageSize);
        }

        public async Task<Account> FetchByName(string name)
        {
            var result = await _context.Accounts.Include(c => c.User).Where(p =>p.AccountName.Equals(name)).FirstAsync();
            return await Task.FromResult(result);
        }

        private async Task<Tuple<int, List<Account>>> FetchPageFromQueryable(IQueryable<Account> queryable, int page,
            int pageSize)
        {
            var count = await queryable.CountAsync();
            var addresses = await queryable.Skip((page - 1) * pageSize).Take(pageSize)
                .Include(a => a.User)
                .ToListAsync();

            return await Task.FromResult(Tuple.Create(count, addresses));
        }

        public Task<int> UpdateAsync(Account account, CreateOrEditAccountDto dto)
        {
            throw new NotImplementedException();
        }
    }
}