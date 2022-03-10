using System.Collections.Generic;

namespace CreditManagementTest.Entities
{
    public class CategoryImage : FileUpload
    {
        public Category Category { get; set; }
        public long CategoryId { get; set; }
        
    }
}