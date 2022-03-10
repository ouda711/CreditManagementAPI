using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.Tag;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Category
{
    public class CategoryListDtoResponse : PagedDto
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
//    public int SortBy {get; set;}


        public static CategoryListDtoResponse Build(List<Entities.Category> categories,
            string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            List<CategoryDto> tagDtos = new List<CategoryDto>(categories.Count);
            foreach (var category in categories)
            {
                tagDtos.Add(CategoryDto.Build(category));
            }

            return new CategoryListDtoResponse
            {
                PageMeta = new PageMeta(categories.Count, basePath, currentPageNumber: currentPage, requestedPageSize: pageSize,
                    totalItemCount: totalItemCount),
                Categories = tagDtos
            };
        }
    }
}