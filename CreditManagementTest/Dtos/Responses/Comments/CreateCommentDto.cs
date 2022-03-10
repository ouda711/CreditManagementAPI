using System;
using System.ComponentModel.DataAnnotations;

namespace CreditManagementTest.Dtos.Responses.Comments
{
    public class CreateCommentDto
    {
        //[Required]
        public long Id { get; set; }

        [Required] public String Slug { get; set; }

        public string ProductId { get; set; }
        [Required] public string Content { get; set; }
    }
}