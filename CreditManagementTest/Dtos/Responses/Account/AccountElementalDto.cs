using Bogus.DataSets;

namespace CreditManagementTest.Dtos.Responses.Account
{
    public class AccountElementalDto
    {
        public long Id { get; set; }
        public string AccountName { get; set; }

        public static AccountElementalDto Build(Entities.Account account)
        {
            return new AccountElementalDto
            {
                Id = account.Id,
                AccountName = account.AccountName
            };
        }
    }
}