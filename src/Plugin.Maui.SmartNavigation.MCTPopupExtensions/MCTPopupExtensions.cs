using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;

namespace Plugin.Maui.SmartNavigation;

public static class MCTPopupExtensions
{
    public static Task<IPopupResult> ShowPopupAsync<T>(this INavigation navigation, IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : Popup
        => navigation.ShowPopupAsync(SmartResolver.Create<T>(), options, cancellationToken);

    public static Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(this INavigation navigation, IPopupOptions? options = null, CancellationToken cancellationToken = default) where T : Popup
        => navigation.ShowPopupAsync<TResult>(SmartResolver.Create<T>(), options, cancellationToken);

    public static Task<IPopupResult> ShowPopupAsync<T>(this INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup
        => navigation.ShowPopupAsync(SmartResolver.Create<T>(parameters), options, cancellationToken);

    public static Task<IPopupResult<TResult>> ShowPopupAsync<T, TResult>(this INavigation navigation, IPopupOptions? options, CancellationToken cancellationToken, params object[] parameters) where T : Popup
        => navigation.ShowPopupAsync<TResult>(SmartResolver.Create<T>(parameters), options, cancellationToken);
}
