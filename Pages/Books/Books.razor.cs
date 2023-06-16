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
    public partial class Books
    {
        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        public Service services { get; set; }
        public List<Book> allBooks { get; set; }



        protected override async Task OnInitializedAsync()
        {
            var re = await services.GetBooks();
            allBooks = re.ToList();
        }

        public void alert()
        {
            Snackbar.Add("clicked!", Severity.Error);
        }

    }
}