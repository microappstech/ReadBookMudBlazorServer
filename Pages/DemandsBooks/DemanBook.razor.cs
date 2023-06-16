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
using ReadBookMuds.Models;
using ReadBookMuds.Services;
using ReadBookMuds.Shared;
using MudBlazor;
using ReadBookMuds.Components;

namespace ReadBookMuds.Pages.DemandsBooks
{
    public partial class DemanBook
    {
        [Parameter] public dynamic name { get; set; }
        [Parameter] public dynamic id { get; set; }
        [Inject] Service? Service { get; set; }

        Book book { get; set; }

        public int nbr { get; set; }
        public bool formIsValid { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? fullname { get; set; }
        public string? Adresse { get; set; }
        public decimal price { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int Id = int.Parse(id);
            book = await Service.GetSingleBook(Id);
            price = book.Price;
        }

        public async void Demand()
        {
            int Id = int.Parse(id);
            DemandBook demandBook = new DemandBook()
            {
                bookId = Id,
                Addresse = Adresse,
                username = fullname,
                phone = phone,
                Email = email,
                nbr = nbr
            };
            var Result = await Service.DemandeBook(demandBook);
            snackbar.Add("Demaond The book " + name, Severity.Success);
            Service?.NavigateTo("/allbooks", true);
        }
    }
}