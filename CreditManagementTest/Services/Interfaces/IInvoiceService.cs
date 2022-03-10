using System.Threading.Tasks;
using CreditManagementTest.Dtos.Requests.Invoice;
using CreditManagementTest.Entities;

namespace CreditManagementTest.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> CreateAsync(ApplicationUser user, string name, CreateOrEditInvoiceDto dto, long userId);
    }
}