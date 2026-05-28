using CommunityToolkit.Maui.Views;

namespace DemoProject.Popups.Pages.Mct.Loader;

public partial class LoadingPopup : Popup
{
    public LoadingPopup(string loadingText)
    {
        InitializeComponent();
        UpdateText(loadingText);
    }

    public void UpdateText(string loadingText)
    {
        LoadingLbl.Text = loadingText;
    }
}