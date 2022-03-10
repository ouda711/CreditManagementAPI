using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Entities;
using BlogDotNet.Models;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Tag
{
    public class TagListDtoResponse : PagedDto
    {
        public IEnumerable<TagDto> Tags { get; set; }
//    public int SortBy {get; set;}


        public static TagListDtoResponse Build(List<Entities.Tag> tags,
            string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            List<TagDto> tagDtos = new List<TagDto>(tags.Count);
            foreach (var tag in tags)
            {
                tagDtos.Add(TagDto.Build(tag));
            }

            return new TagListDtoResponse
            {
                PageMeta = new PageMeta(tags.Count, basePath, currentPageNumber: currentPage, requestedPageSize: pageSize,
                    totalItemCount: totalItemCount),
                Tags = tagDtos
            };
        }
    }
}