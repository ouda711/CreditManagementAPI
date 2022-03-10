using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Models;
using CreditManagementTest.Models.ViewModels.User;

namespace CreditManagementTest.Dtos.Responses.Comments
{
    class CommentListDto : SuccessResponse
    {
        
        public PageMeta PageMeta { get; set; }
        public ICollection<CommentDetailsDto> Comments { get; set; }

        public static CommentListDto Build(ICollection<Entities.Comment> comments,
            string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            ICollection<CommentDetailsDto> result = new List<CommentDetailsDto>();

            foreach (var comment in comments)
                result.Add(CommentDetailsDto.Build(comment, false, true));

            return new CommentListDto
            {
                Success = true,
                PageMeta = new PageMeta(result.Count, basePath, currentPageNumber: currentPage, requestedPageSize: pageSize,
                    totalItemCount: totalItemCount),
                Comments = result
            };
        }
    }
}