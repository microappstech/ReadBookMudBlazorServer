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
    public partial class ListDemandBook
    {

        [Inject] Service Services { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        public List<DemandBook> Orders { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Orders = await Services.GetOrders();
        }
        public async Task Delete(int id)
        {
            bool? Confirm = await DialogService.ShowMessageBox("Confirmation", (MarkupString)$"Are you sure you want to delete ",
                yesText : "Yes", cancelText : "Non");

            if (Confirm==true)
            {
                var ResultDelete = await Services.DeleteDemand(id);
                Orders = await Services.GetOrders();
                await InvokeAsync(StateHasChanged);
                StateHasChanged();
            }
        }


    }
}