using System;
using System.Collections.Generic;
using System.Linq;
using CreditManagementTest.Dtos.Responses.Category;
using CreditManagementTest.Dtos.Responses.Comments;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.Tag;
using CreditManagementTest.Entities;

namespace CreditManagementTest.Dtos.Responses
{
    public class ProductDetailsDto : SuccessResponse
    {
        public long Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }


        public int Price { get; set; }
        public string Description { get; set; }

        public DateTime ModifiedAt { get; set; }
        public DateTime PublishedAt { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public List<string> Tags { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }

        // public IEnumerable<CommentIntrinsicInfoDto> Comments { get; set; }
        public IEnumerable<CommentDetailsDto> Comments { get; set; }

        public static ProductDetailsDto Build(Product product)
        {
            var commentDtos = new List<CommentDetailsDto>();
            if (product.Comments != null)
            {
                foreach (var comment in product.Comments)
                {
                    commentDtos.Add(CommentDetailsDto.Build(comment));
                }
            }

            return new ProductDetailsDto
            {
                Id = product.Id,
                Name = product.Name,
                Slug = product.Slug,
                Price = product.Price,
                Description = product.Description,
                PublishedAt = product.PublishAt,
                ImageUrls = product.ProductImages.Select(pi => pi.FilePath)
            };
        }
    }
}