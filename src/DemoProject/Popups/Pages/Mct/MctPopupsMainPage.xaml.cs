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
}