using CommunityToolkit.Maui.Views;

namespace DemoProject.Popups.Pages.Mct;

public partial class ReturnObjectPopup : Popup
{
	public ReturnObjectPopup()
	{
		InitializeComponent();
	}

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await CloseAsync();
    }
}