using LoginSipetro.Models;


namespace LoginSipetro.Services
{
    public interface IAccountService
    {
        public Account Login(string username, string password);
    }
}
