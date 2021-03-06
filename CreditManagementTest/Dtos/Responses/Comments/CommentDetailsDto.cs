using System;
using CreditManagementTest.Dtos.Responses.Products;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.User;
using CreditManagementTest.Entities;

namespace CreditManagementTest.Dtos.Responses.Comments
{
    public class CommentDetailsDto : SuccessResponse
    {
        public long Id { get; set; }
        public ProductElementalDto Product { get; set; }
        public string Content { get; set; }
        public int? Rating { get; set; }

        public UserBasicEmbeddedInfoDto User { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }


        // public Comment Comment {get; set;}
        public static CommentDetailsDto Build(Comment comment, bool includeProduct = false,
            bool includeUser = false)
        {
            var dto = new CommentDetailsDto
            {
                Id = comment.Id,
                Content = comment.Content,
                Rating = comment.Rating,
                CreatedAt = comment.CreatedAt,
                UpdatedAt = comment.UpdatedAt
            };

            if (includeProduct)
                dto.Product = new ProductElementalDto
                {
                    Id = comment.ProductId,
                    Name = comment.Product.Name,
                    Slug = comment.Product.Slug,
                };
            if (includeUser)
                dto.User = UserBasicEmbeddedInfoDto.Build(comment.User);

            return dto;
        }
    }
}