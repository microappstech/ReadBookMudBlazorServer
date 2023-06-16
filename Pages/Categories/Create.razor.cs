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
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace ReadBookMuds.Pages.Categories
{
    public partial class Create
    {
        MudForm formCate;
        public Category Category;
        [Inject]
        protected NavigationManager UriHelper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = new Category();
        }

        public async Task Save()
        {
            try
            {
                var resultSave = await ServiceCategory.CreateCategory(Category);
                if (resultSave != null)
                {
                    await InvokeAsync(StateHasChanged);
                    UriHelper.NavigateTo("/categories", true);
                }
            }
            catch (Exception ex)
            {
            }
        }

        bool success;
        string[] errors =
        {
        };
    }
}