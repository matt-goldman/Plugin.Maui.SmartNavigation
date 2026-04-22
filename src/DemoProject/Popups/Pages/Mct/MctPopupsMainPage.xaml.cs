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
        try
        {
            await Navigation.PushAsync<MessagePopup>(null, CancellationToken.None, new MessagePopupModel
            {
                Title = "Test message popup title",
                Message = "Test message popup message"
            });
        }
        catch (Exception ex)
        {

        }
    }

    private async void OnAddPopup_Clicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync<AddPopup>(null, CancellationToken.None);
        }
        catch (Exception ex)
        {

        }
    }

    private async void OnLoadingPopups_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoadingPopups());
    }

    private async void OnReturnObjectPopup_Clicked(object sender, EventArgs e)
    {
        try
        {
            IPopupResult result = await Navigation.PushAsync<ReturnObjectPopup>(null, CancellationToken.None);

            if (result is IPopupResult popupResult)
            {
                TestObject testObj = new TestObject
                {
                    Id = 123,
                    Description = "Returned from Popup"
                };

                await DisplayAlertAsync("Return Object Result", testObj.ToString(), "OK");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
        }
    }

    private async void OnEasyPopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync<MctEasyPopup>(null, CancellationToken.None);
    }

    private async void OnMctParamPopup_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync<MctParamPopup>(null, CancellationToken.None, "It's alive!");
    }

    public class TestObject
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Description: {Description}";
        }
    }
}