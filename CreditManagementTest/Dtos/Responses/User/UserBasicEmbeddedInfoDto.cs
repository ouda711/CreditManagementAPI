using CreditManagementTest.Entities;
using Newtonsoft.Json;

namespace CreditManagementTest.Dtos.Responses.User
{
    public class UserBasicEmbeddedInfoDto
    {
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        public long Id { get; set; }

        public static UserBasicEmbeddedInfoDto Build(ApplicationUser user)
        {
            return new UserBasicEmbeddedInfoDto
            {
                UserName = user.UserName,
                Id = user.Id
            };
        }
    }
}