using CommunityToolkit.Maui.Extensions;

namespace DemoProject.Popups.Pages.Mct.Loader;

public class AppLoader : IAsyncDisposable
{
    private LoadingPopup? _loadingPopup;
    private bool _disposed;

    private AppLoader() { }

    public static async Task<AppLoader> CreateAsync(string loadingText = "Loading")
    {
        var loader = new AppLoader();
        loader.ShowLoader(loadingText);
        return loader;
    }

    public void ShowLoader(string loadingText = "Loading")
    {
        if(Application.Current?.MainPage == null) return;

        // If a popup is already active, close it before opening a new one
        if(_loadingPopup != null)
        {
            HideLoader();
        }

        _loadingPopup = new LoadingPopup(loadingText);
        Application.Current.MainPage.ShowPopup(_loadingPopup);
    }

    public void HideLoader()
    {
        if(_loadingPopup != null)
        {
            try
            {
                _loadingPopup.CloseAsync();
            }
            catch(Exception)
            {
                //! Important - thrown if loading pop up has already been removed
            }
            finally
            {
                _loadingPopup = null;
            }
        }
    }

    public void UpdateText(string loadingText)
    {
        _loadingPopup?.UpdateText(loadingText);
    }

    public ValueTask DisposeAsync()
    {
        if(!_disposed)
        {
            HideLoader();
            _disposed = true;
        }

        return ValueTask.CompletedTask;
    }
}
