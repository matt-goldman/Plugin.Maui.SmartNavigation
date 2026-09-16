using CommunityToolkit.Maui.Core;
using DemoProject.Popups.Pages.Mct.Loader;

namespace DemoProject.Popups.Pages.Mct;

public partial class MctPopupsMainPage : ContentPage
{
    public MctPopupsMainPage()
    {
        InitializeComponent();
    }

    private async void OnMessagePopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.ShowPopupAsync<MessagePopup>(null, CancellationToken.None, new MessagePopupModel
        {
            Title = "Test message popup title",
            Message = "Test message popup message"
        });
    }

    private async void OnAddPopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.ShowPopupAsync<AddPopup>();
    }

    private async void OnLoadingPopups_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoadingPopups());
    }

    private async void OnReturnObjectPopup_Clicked(object sender, EventArgs e)
    {
        IPopupResult<TestObject> result = await Navigation.ShowPopupAsync<ReturnObjectPopup, TestObject>();

        if (!result.WasDismissedByTappingOutsideOfPopup && result.Result is TestObject testObj)
        {
            await DisplayAlertAsync("Return Object Result", testObj.ToString(), "OK");
        }
    }

    private async void OnEasyPopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.ShowPopupAsync<MctEasyPopup>();
    }

    private async void OnMctParamPopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.ShowPopupAsync<MctParamPopup>(null, CancellationToken.None, "It's alive!");
    }
}
