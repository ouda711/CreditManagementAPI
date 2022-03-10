using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CreditManagementTest.Data;
using CreditManagementTest.Dtos.Requests.Invoice;
using CreditManagementTest.Entities;
using CreditManagementTest.Services.Interfaces;

namespace CreditManagementTest.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly HtmlEncoder _htmlEncoder;

        public InvoiceService(ApplicationDbContext context, IAccountService accountService, HtmlEncoder htmlEncoder)
        {
            _context = context;
            _accountService = accountService;
            _htmlEncoder = htmlEncoder;
        }


        public  async Task<Invoice> CreateAsync(ApplicationUser user, string name, CreateOrEditInvoiceDto dto, long userId)
        {
            var account = await _accountService.FetchByName(name);

            var invoice = new Invoice()
            {
                Account = account,
                Amount = dto.Amount,
                DueDate = dto.DueDate,
                User = user,
                UserId = userId,
                Status = "pending",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Invoices.AddAsync(invoice);
            account.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return invoice;
        }
    }
}