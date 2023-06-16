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
using ReadBookMuds.Shared;
using MudBlazor;
using ReadBookMuds.Components;
using ReadBookMuds.Services;
using ReadBookMuds.Models;

namespace ReadBookMuds.Pages.Categories
{
    public partial class Index
    {
        public List<Category> Categories;
        protected override async Task OnInitializedAsync()
        {
            Categories = await ServiceCategy.GetCategories();
        }

        private async void Delete(int id)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Are you sure you want to remove this category");
            parameters.Add("ButtonText", "Yes");
            parameters.Add("Color", Color.Success);
            var result = await DialogService.Show<Dialog>("Confirm", parameters).Result;
            if (!result.Canceled)
            {
                var resultdelete = await ServiceCategy.DeleteCategory(id);
                Categories = await ServiceCategy.GetCategories();
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}