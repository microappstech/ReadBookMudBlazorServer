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

namespace ReadBookMuds.Pages.Books
{
    public partial class Index
    {
        public List<Book> Books;
        protected override async Task OnInitializedAsync()
        {
            var re = await ServiceBook.GetBooks();
            Books = re.ToList();
        }

        private async void Confirm(int id)
        {
            var parameters = new DialogParameters();
            parameters.Add("ContentText", "Are you sure you want to remove this book");
            parameters.Add("ButtonText", "Yes");
            parameters.Add("Color", Color.Success);
            var result = await DialogServicee.Show<Dialog>("Confirm", parameters).Result;
            if (!result.Cancelled)
            {
                var resultdelete = await ServiceBook.DeleteBook(id);
                var r = await ServiceBook.GetBooks();
                Books = r.ToList();
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}