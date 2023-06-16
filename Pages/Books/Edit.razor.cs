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

namespace ReadBookMuds.Pages.Books
{
    public partial class Edit
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        NavigationManager uriHelper { get; set; }

        public Book book { get; set; }

        List<Category> Categories = new List<Category>();
        protected override async Task OnInitializedAsync()
        {
            book = await ServiceBook.GetSingleBook(Id);
            Categories = await ServiceBook.GetCategories();
        }

        public async void UploadIcon(IBrowserFile icon)
        {
            MemoryStream ms = new MemoryStream();
            await icon.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(ms);
            var bytes = ms.ToArray();
            string base64ImageRepresentation = Convert.ToBase64String(bytes);
            book.Icon = "data:image/png;base64," + base64ImageRepresentation;
        }

        bool success;
        string[] errors =
        {
        };
        MudTextField<string> pwField1;
        MudForm form;
        public async Task Save()
        {
            var resultSave = await ServiceBook.EditBook(book);
            uriHelper.NavigateTo("/books", true);
        }
    }
}