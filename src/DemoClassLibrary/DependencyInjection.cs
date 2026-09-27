using DemoClassLibrary.Pages;
using Plugin.Maui.SmartNavigation.Attributes;

namespace DemoClassLibrary;

[UseAutoDependencies]
public static class DependencyInjection
{
    extension(MauiAppBuilder builder)
    {
        public MauiAppBuilder AddClassLibrary()
        {
            // shell routes not used in demo but you could do this:
            //Routing.RegisterRoute("//classlib", typeof(ClassLibPage));
            return builder.UseAutodependencies();
        }
    }
}