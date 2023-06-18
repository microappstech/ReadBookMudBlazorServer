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

namespace ReadBookMuds.Pages.DemandsBooks
{
    public partial class EditDomandBook
    {
        [Parameter] public int Id { get; set; }
        [Inject] public Service Services { get; set; }
        public DemandBook demandBook { get; set; }
        public bool formIsValid { get; set; }
        protected override async Task OnInitializedAsync()
        {
            demandBook = await Services.GetDemandBookById(Id);
        }
        public async Task Save()
        {
            var result = Services.EditDemand(Id, demandBook);
        }
    }
}