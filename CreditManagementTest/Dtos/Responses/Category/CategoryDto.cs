using System.Collections.Generic;
using CreditManagementTest.Dtos.Responses.Shared;
using CreditManagementTest.Dtos.Responses.Tag;

namespace CreditManagementTest.Dtos.Responses.Category
{
    public class CategoryDto : SuccessResponse
    {
        public long Id { get; set; }
        public List<string> ImageUrls { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public static CategoryDto Build(Entities.Category category)
        {
            List<string> imageUrls = new List<string>();
            if (category.CategoryImages != null)
            {
                foreach (var tagImage in category.CategoryImages)
                {
                    imageUrls.Add(tagImage.FilePath);
                }
            }

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrls = imageUrls
            };
        }
    }
}