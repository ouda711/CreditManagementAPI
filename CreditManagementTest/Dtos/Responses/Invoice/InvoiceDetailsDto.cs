using System;
using CreditManagementTest.Dtos.Responses.Account;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.User;

namespace CreditManagementTest.Dtos.Responses.Invoice
{
    public class InvoiceDetailsDto : SuccessResponse
    {
        public long Id { get; set; }
        public DateTime DueDate { get; set; }
        public int Amount { get; set; }
        
        public string Status { get; set; }
        public AccountElementalDto Account { get; set; }
        public UserBasicEmbeddedInfoDto User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static InvoiceDetailsDto Build(Entities.Invoice invoice, bool includeAccount = false,
            bool includeUser = false)
        {
            var dto = new InvoiceDetailsDto
            {
                Id = invoice.Id,
                Amount = invoice.Amount,
                DueDate = invoice.DueDate,
                CreatedAt = invoice.CreatedAt,
                UpdatedAt = invoice.UpdatedAt
            };

            if (includeAccount)
            {
                dto.Account = new AccountElementalDto
                {
                    Id = invoice.AccountId
                };
            }

            if (includeUser)
            {
                dto.User = UserBasicEmbeddedInfoDto.Build(invoice.User);
            }

            return dto;
        }
    }
}