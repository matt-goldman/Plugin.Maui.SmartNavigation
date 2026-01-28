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

			public class HomePageViewModel { }

			public interface IMyService { }

			public class MyService : IMyService { }
			""";

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

            public class HomePageViewModel { }

            public interface IMyService { }

            public class MyService : IMyService { }
            """;

        // Assert
        await TestHelper.Verify(source);
    }
}
