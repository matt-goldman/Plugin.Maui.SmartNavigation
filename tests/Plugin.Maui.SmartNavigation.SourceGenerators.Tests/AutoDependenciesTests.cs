using IeuanWalker.MinimalApi.Endpoints.Generator.Tests;

namespace Plugin.Maui.SmartNavigation.SourceGenerators.Tests;

public sealed class AutoDependenciesTests
{
    [Fact]
    public async Task AutoDependencies_UseAutoDependenciesAttributeNotFound_DontGenertateAnySourceCode()
    {
        // Arrange
        const string source = """
			namespace TestAssembly;

			public static class MauiProgram
			{
				public static MauiApp CreateMauiApp()
				{
				}
			}

			public class HomePage { }
			public class Test1Page { }
			public class Test2Page { }
			public class Test3Page { }

			public class HomePageViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class Test1ViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class Test2ViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class Test3ViewModel { }


			public class MyService { }
			public interface IMy2Service { }
			public class My2Service : IMyService { }

			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class IngoreService : IIngoreService { }
			public interface IIngoreService { }
			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class Ingore2Service { }

			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class SingletonService : ISingletonService { }
			public interface ISingletonService { }
			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class Singleton2Service { }

			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class TransientService : ITransientService { }
			public interface ITransientService { }
			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class Transient2Service { }
			""";

        // Assert
        await TestHelper.Verify(source);
    }

    [Fact]
    public async Task AutoDependencies_GeneratesRegs_ForPagesViewModelsAndServices()
    {
        // Arrange
        const string source = """
			namespace TestAssembly;

			[Plugin.Maui.SmartNavigation.Attributes.UseAutoDependenciesAttribute]
			public static class MauiProgram
			{
				public static MauiApp CreateMauiApp()
				{
				}
			}

			public class HomePage { }
			public class Test1Page { }
			public class Test2Page { }
			public class Test3Page { }

			public class HomePageViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class Test1ViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class Test2ViewModel { }
			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class Test3ViewModel { }


			public class MyService { }
			public interface IMy2Service { }
			public class My2Service : IMyService { }

			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class IngoreService : IIngoreService { }
			public interface IIngoreService { }
			[Plugin.Maui.SmartNavigation.Attributes.IgnoreAttribute]
			public class Ingore2Service { }

			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class SingletonService : ISingletonService { }
			public interface ISingletonService { }
			[Plugin.Maui.SmartNavigation.Attributes.SingletonAttribute]
			public class Singleton2Service { }

			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class TransientService : ITransientService { }
			public interface ITransientService { }
			[Plugin.Maui.SmartNavigation.Attributes.TransientAttribute]
			public class Transient2Service { }
			""";

        // Assert
        await TestHelper.Verify(source);
    }
}
