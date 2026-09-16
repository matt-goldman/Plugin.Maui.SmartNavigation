using CommunityToolkit.Maui.Views;

namespace DemoProject.Popups.Pages.Mct;

public partial class ReturnObjectPopup : Popup<TestObject>
{
    public ReturnObjectPopup()
    {
        InitializeComponent();
    }

    private async void OnCloseClicked(object sender, EventArgs e)
    {
        await CloseAsync(new TestObject
        {
            Id = 123,
            Description = "Returned from Popup"
        });
    }
}
