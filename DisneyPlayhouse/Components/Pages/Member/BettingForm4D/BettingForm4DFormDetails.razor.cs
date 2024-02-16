using DisneyPlayhouse.Models;
using DisneyPlayhouseLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace DisneyPlayhouse.Components.Pages.Member.BettingForm4D
{
    public partial class BettingForm4DFormDetails
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthStateTask { get; set; }

        [Parameter] public double TotalBig { get; set; }
        [Parameter] public double TotalSmall { get; set; }
        [Parameter] public double TotalAmount { get; set; }

        private List<ILib_ListOfChildIdModel> names = new List<ILib_ListOfChildIdModel>();
        private BetFormDetailsModel betFormDetailsModel = new BetFormDetailsModel();
        private string? currentUserId = "";
        [Parameter] public EventCallback<string> OnBelongsToSet { get; set; }
        [Parameter] public EventCallback<string> OnPurchasedByWhoSet { get; set; }
        [Parameter] public EventCallback<string> PageNameSet { get; set; }
        [Parameter] public EventCallback ResetFormSet { get; set; }
        [Parameter] public EventCallback submitFormSet { get; set; }

        protected override async Task OnInitializedAsync()
        {
            currentUserId = AuthStateTask.Result.User.Identity.Name;
            names = await memberData.GetListOfChildId(currentUserId);
            betFormDetailsModel.PurchasedById = currentUserId;
        }

        private async Task OnValueChangedBelongsToId(string value)
        {
            betFormDetailsModel.BelongsToId = value;
            await OnBelongsToSet.InvokeAsync(value);
            await OnPurchasedByWhoSet.InvokeAsync(currentUserId);
        }

        private async Task OnValueChangedPageName(string value)
        {
            betFormDetailsModel.PageName = value;
            await PageNameSet.InvokeAsync(value);
        }

        private async Task OnHandleResetForm()
        {
            await ResetFormSet.InvokeAsync();
        }

        private async Task OnHandleSubmitForm()
        {
            await submitFormSet.InvokeAsync();
        }
    }
}