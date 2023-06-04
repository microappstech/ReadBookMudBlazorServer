using Microsoft.AspNetCore.Identity;

namespace ReadBookMuds.Areas.IdentityServices
{
    public class Security
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        public Security(SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this._roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public  async void CreateAdmin()
        {
            var userAdmin = Activator.CreateInstance<IdentityUser>(); 
            if(userAdmin != null) {
                IdentityRole admin = new IdentityRole("Admin");
                var role = await _roleManager.CreateAsync(admin);
                if (role.Succeeded)
                {
                    _userManager.AddToRoleAsync(userAdmin,"Admin");
                }
            }
        }









    }
}
