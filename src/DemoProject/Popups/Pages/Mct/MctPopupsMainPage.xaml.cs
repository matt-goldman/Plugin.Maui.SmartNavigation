using CommunityToolkit.Maui.Core;

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