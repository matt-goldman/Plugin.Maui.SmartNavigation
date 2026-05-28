namespace DemoProject.Popups.Pages.Mct.Loader;

public partial class LoadingPopups : ContentPage
{
	public LoadingPopups()
	{
		InitializeComponent();
    }

    private async void OnLoaderPopup_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync();

        await Task.Delay(2000);
    }

    private async void TryFinallyExample_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync();

        await Task.Delay(2000);
    }

    private async void WithErrorMessage_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync();

        try
        {
            await Task.Delay(2000);
            throw new Exception();
        }
        catch(Exception ex)
        {
            await DisplayAlertAsync("Error", ex.Message, "Cancel");
        }
    }

    private async void WithCustomText_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync("Custom loading message");

        await Task.Delay(2000);
    }

    private async void ChangingMessage_Clicked(object sender, EventArgs e)
    {
        await using AppLoader loader = await AppLoader.CreateAsync();

        await Task.Delay(1000);
        loader.UpdateText("Text 1");
        await Task.Delay(1000);
        loader.UpdateText("Text 2");
        await Task.Delay(1000);
        loader.UpdateText("Text 3");
        await Task.Delay(1000);
    }
}