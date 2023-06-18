using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using ReadBookMuds.Data;
using ReadBookMuds.Data.Constant;
using ReadBookMuds.Models.Identity;
using ReadBookMuds.Pages.Users;
using System.Threading;
using System.Xml.Linq;

namespace ReadBookMuds.Areas.IdentityServices
{
    public class Security
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ApplicationDbContext _contextUsers;
        private readonly NavigationManager UriHelper;
        public Security(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context, NavigationManager UriHelper)
        {
            this._roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _contextUsers = context;
            this.UriHelper = UriHelper;
        }
        /*
        public async Task<bool> InitializeAsync(AuthenticationStateProvider authenticationStateProvider)
        {
            var authenticationState = await authenticationStateProvider.GetAuthenticationStateAsync();
            Principal = authenticationState.User;

            var name = Principal.Identity.Name;


            if (user == null && name != null)
            {
                await semaphoreSlim.WaitAsync();
                try
                {
                    user = await userManager.FindByNameAsync(name);

                    //if(user == null)
                    //{
                    //    user = await userManager.FindByEmailAsync(name);
                    //}

                    if(user != null)
                    {
                        user.RoleNames = await userManager.GetRolesAsync(user);
                    }
                }
                                finally
                                {
                    semaphoreSlim.Release();
                }
                            }

                            var result = IsAuthenticated();
                if (result)
                {
                    Authenticated?.Invoke();
                }

                return result;
                        } 

         * */
        //public ApplicationUser User { get; set; }

        public  async void CreateAdmin()
        {
            var userAdmin = Activator.CreateInstance<ApplicationUser>(); 
            if(userAdmin != null) {
                IdentityRole admin = new IdentityRole(Roles.Admin.ToString());
                var role = await _roleManager.CreateAsync(admin);
                if (role.Succeeded)
                {
                    await _userManager.AddToRoleAsync(userAdmin,Roles.Admin.ToString());
                }
            }
        }

        public async Task<List<ApplicationUser>> Users()
        {
            var users = _contextUsers.Users.ToList();
            return await Task.FromResult(users);
        }

        public async Task<ApplicationUser> CreateUser(string RoleName, string Password)
        {
            var user =  Activator.CreateInstance<ApplicationUser>();
            List<string> AllowedRoles = new List<string> { Roles.Manager.ToString(), Roles.Admin.ToString(), Roles.User.ToString() };
            if (!string.IsNullOrEmpty(RoleName) && !AllowedRoles.Contains(RoleName))
            {
                throw new Exception("The role is not allowed");
            }
            var result = await _userManager.CreateAsync(user, Password);
            var role = _roleManager.FindByNameAsync(RoleName);
            if (role == null)
            {
                IdentityRole identityRole = new IdentityRole(RoleName.ToString());
               var trole = await _roleManager.CreateAsync(identityRole);
            }
            await _userManager.AddToRoleAsync(user, RoleName);
            return user;
        }

        public async Task<ApplicationUser> DeleteUser(string id)
        {
            var UserToDelete = await _userManager.FindByIdAsync(id);
            if(UserToDelete == null)
            {
                throw new Exception("The User already deleted ");
            }
            
            try
            {
                var UserRoles = await _userManager.GetRolesAsync(UserToDelete);
                if(UserRoles !=null)
                {
                    var removeroles = _userManager.RemoveFromRolesAsync(UserToDelete, UserRoles);
                }
                var result = await _userManager.DeleteAsync(UserToDelete);
                
            }
            catch (Exception ex) 
            { 

            }
            return await Task.FromResult(UserToDelete);
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            var user = await GetUserById(id);
            if (user == null)
            {
                throw new Exception("The User Not Exist!!");
            }
            return await Task.FromResult(user);
            
        }

        public async Task<ApplicationUser> Edit(string id, ApplicationUser user)
        {
            try
            {
                var UserToUpdate = await _userManager.FindByIdAsync(id);
                if (UserToUpdate == null)
                {
                    throw new Exception("The User already deleted ");
                }
                UserToUpdate.PhoneNumber = user.PhoneNumber;
                UserToUpdate.UserName = user.UserName;
                UserToUpdate.Email = user.Email;    
                UserToUpdate.Icon = user.Icon;
                UserToUpdate.FullName = user.FullName;
                var result = await _userManager.UpdateAsync(UserToUpdate);
                if (result.Succeeded)
                {
                    var Roles = _userManager.AddToRolesAsync(UserToUpdate, user.Roles);
                }
            }
            catch (Exception ex)
            {

            }
            return await Task.FromResult(user);

        }

        static SemaphoreSlim _lockGetUserById = new SemaphoreSlim(1, 1);
        public async Task<ApplicationUser> GetUserById(string id)
        {
            await _lockGetUserById.WaitAsync();
            try
            {
                var user = _userManager.FindByIdAsync(id).Result;

                if (user != null)
                {
                    //user.Roles = _userManager.GetRolesAsync(user).Result;
                }

                return await Task.FromResult(user);
            }
            finally
            {
                _lockGetUserById.Release();
            }
        }



    }
}
