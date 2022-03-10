using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Invoice
{
    public class InvoiceListDto : SuccessResponse
    {
        public PageMeta PageMeta { get; set; }
        public ICollection<InvoiceDetailsDto> Invoices { get; set; }

        public static InvoiceListDto Build(ICollection<Entities.Invoice> invoices, string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            ICollection<InvoiceDetailsDto> result = new List<InvoiceDetailsDto>();

            foreach (var invoice in invoices)
            {
                result.Add(InvoiceDetailsDto.Build(invoice, false, true));
            }

            return new InvoiceListDto
            {
                Success = true,
                PageMeta = new PageMeta(result.Count, basePath, currentPageNumber: currentPage,
                    requestedPageSize: pageSize, totalItemCount: totalItemCount),
                Invoices = result
            };
        }
    }
}