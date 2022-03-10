using System.Collections.Generic;

namespace CreditManagementTest.Entities
{
    public class TagImage : FileUpload
    {
        public Tag Tag { get; set; }
        public long TagId { get; set; }
    }
}