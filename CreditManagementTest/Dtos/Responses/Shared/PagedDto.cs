using BlogDotNet.Models;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Shared
{
    public abstract class PagedDto : SuccessResponse
    {
        public PageMeta PageMeta { get; set; }
    }
}