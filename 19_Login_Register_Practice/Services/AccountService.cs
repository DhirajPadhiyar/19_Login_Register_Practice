using _19_Login_Register_Practice.Models;
using Microsoft.AspNetCore.Identity;

namespace _19_Login_Register_Practice.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<bool> LoginAsync(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                false, false);//तीसरा Parameter यह Remember Me के लिए है।
            //अगर true तो Browser बंद करने के बाद भी user Login रहेगा।
            //false तो Browser बंद होते ही Login समाप्त हो जाएगा।

            //चौथा Parameter false
            //यह Lockout on Failure के लिए है।
            //अगर true तो कई बार गलत password डालने पर account कुछ समय के लिए lock हो सकता है।
            //अगर false तो गलत password पर lock नहीं होगा।
            return result.Succeeded;

        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser
            {
                UserName= model.UserName,
                Email=model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            return result.Succeeded;

        }
    }
}
