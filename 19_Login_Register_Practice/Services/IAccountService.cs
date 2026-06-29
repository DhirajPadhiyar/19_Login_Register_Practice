using _19_Login_Register_Practice.Models;

namespace _19_Login_Register_Practice.Services
{
    public interface IAccountService
    {
        Task<bool> RegisterAsync(RegisterModel model);
        Task<bool> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<bool> EmailExistsAsync(string email);
    }
}
