using Plugin.Maui.SmartNavigation.Extensions;
using Shouldly;
using System.Reflection;

namespace Plugin.Maui.SmartNavigation.IntegrationTests.Tests.NavigationTests;

public class WindowNavigationExtensionMethodTests
{
    [Fact]
    public void NavigationExtensions_ShouldExpose_CreateNewWindow_ParameterlessOverload()
    {
        var methods = typeof(NavigationExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == nameof(NavigationExtensions.CreateNewWindow))
            .ToArray();

        methods.Length.ShouldBe(2);
        methods.ShouldContain(m =>
            m.GetParameters().Length == 0
            && m.GetGenericArguments().Length == 1);
    }

    [Fact]
    public void NavigationExtensions_ShouldExpose_CreateNewWindow_ParameterizedOverload()
    {
        var methods = typeof(NavigationExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == nameof(NavigationExtensions.CreateNewWindow))
            .ToArray();

        methods.ShouldContain(m =>
            m.GetParameters().Length == 1
            && m.GetParameters()[0].ParameterType == typeof(object[])
            && m.GetGenericArguments().Length == 1);
    }

    [Fact]
    public void NavigationExtensions_ShouldExpose_OpenNewWindow_ParameterlessOverload()
    {
        var methods = typeof(NavigationExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == nameof(NavigationExtensions.OpenNewWindow))
            .ToArray();

        methods.Length.ShouldBe(2);
        methods.ShouldContain(m => m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(Application));
    }

    [Fact]
    public void NavigationExtensions_ShouldExpose_OpenNewWindow_ParameterizedOverload()
    {
        var methods = typeof(NavigationExtensions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .Where(m => m.Name == nameof(NavigationExtensions.OpenNewWindow))
            .ToArray();

        methods.ShouldContain(m =>
            m.GetParameters().Length == 2
            && m.GetParameters()[0].ParameterType == typeof(Application)
            && m.GetParameters()[1].ParameterType == typeof(object[]));
    }
}
