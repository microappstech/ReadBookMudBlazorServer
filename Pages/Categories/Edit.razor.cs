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
using ReadBookMuds.Components;

namespace ReadBookMuds.Pages.Categories
{
    public partial class Edit
    {
        [Parameter]
        public int id { get; set; }

        MudForm formCate;
        public Category Category = new Category();
        protected override async Task OnInitializedAsync()
        {
            Category = await ServiceCategory.GetSingleCategory(id);
        }

        public async Task Save()
        {
            var resultSave = await ServiceCategory.EditCategory(id, Category);
            NavigationManager.NavigateTo("/categories", true);
        }

        bool success;
        string[] errors =
        {
        };
    }
}