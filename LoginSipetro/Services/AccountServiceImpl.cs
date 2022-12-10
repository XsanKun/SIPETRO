using LoginSipetro.Models;

namespace LoginSipetro.Services
{
    public class AccountServiceImpl : IAccountService
    {

        private List<Account> accounts;

        public AccountServiceImpl()
        {
            accounts = new List<Account>
            {
                new Account
                {
                    Id= 1,
                    Username= "admin@gmail.com",
                    Password= "admin",
                },

                new Account
                {
                    Id= 2,
                    Username= "user@gmail.com",
                    Password= "user",
                }
            };
        }

        public Account Login(string username, string password)
        {
            return accounts.SingleOrDefault(a => a.Username == username && a.Password == password); 
        }
    }
}
