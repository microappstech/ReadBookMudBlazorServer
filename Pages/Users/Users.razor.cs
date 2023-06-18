using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ReadBookMuds;
using ReadBookMuds.Models;
using ReadBookMuds.Services;
using ReadBookMuds.Shared;
using MudBlazor;
using ReadBookMuds.Areas.IdentityServices;
using ReadBookMuds.Components;
using ReadBookMuds.Models.Identity;


namespace ReadBookMuds.Pages.Users
{
    public partial class Users
    {

        [Inject] public Security Security { get; set; }
        public List<ApplicationUser> AllUsers { get; set; }


        protected override async Task OnInitializedAsync()
        {
            AllUsers = await Security.Users();
        }
        public async Task Delete(string id)
        {
            var result = await Security.DeleteUser(id);
        }
    }
}