using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.SmartNavigation.Extensions;

namespace Plugin.Maui.SmartNavigation;

public static class MCTPopupExtensions
{
    public static Task<IPopupResult> PushAsync<T>(this INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>();

        var test = popup as Popup
             ?? throw new ArgumentException("Could not resolve popup page");

        return navigation.ShowPopupAsync(test, options, cancellationToken);
    }
    public static Task<IPopupResult> PushAsync<T>(this INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup
    {
        var popup = NavigationExtensions.ResolvePage<T>(parameters) as Popup
           ?? throw new ArgumentException("Could not resolve popup page");

        return navigation.ShowPopupAsync(popup, options, cancellationToken);
    }
    public static Task<IPopupResult<TResult>> PushAsync<T, TResult>(this INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken) where T : Page
    {
        var popup = NavigationExtensions.ResolvePage<T>() as Popup
          ?? throw new ArgumentException("Could not resolve popup page");

        return navigation.ShowPopupAsync<TResult>(popup, options, cancellationToken);
    }
    //public static Task<IPopupResult<TResult>> PushAsync<T, TResult>(this IPopupService popupService, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Page
    //{
    //    var popup = NavigationExtensions.ResolvePage<T>(parameters) as Page
    //      ?? throw new ArgumentException("Could not resolve popup page");

    //    return popupService.ShowPopupAsync<T, TResult>(popup, options, cancellationToken);
    //}
}
