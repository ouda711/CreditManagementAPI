using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Entities;
using BlogDotNet.Models;
using CreditManagementTest.Models;

namespace CreditManagementTest.Dtos.Responses.Products
{
    public class ProductListDtoResponse : PagedDto 
    {
        public IEnumerable<ProductSummaryDto> Products { get; set; }
//    public int SortBy {get; set;}


        public static ProductListDtoResponse Build(List<Product> products,
            string basePath,
            int currentPage, int pageSize, int totalItemCount)
        {
            List<ProductSummaryDto> productSummaryDtos = new List<ProductSummaryDto>(products.Count);
            foreach (var product in products)
            {
                productSummaryDtos.Add(ProductSummaryDto.Build(product));
            }

            return new ProductListDtoResponse
            {
                PageMeta = new PageMeta(products.Count, basePath, currentPageNumber: currentPage, requestedPageSize: pageSize,
                    totalItemCount: totalItemCount),
                Products = productSummaryDtos
            };
        }
    }
}