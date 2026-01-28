using IeuanWalker.MinimalApi.Endpoints.Generator.Tests;

namespace Plugin.Maui.SmartNavigation.SourceGenerators.Tests;

public sealed class AutoDependenciesTests
{
    [Fact]
    public async Task AutoDependencies_UseAutoDependenciesAttributeNotFound_DontGenertateAnySourceCode()
    {
        // Arrange
        const string source = """
			namespace DemoProject;

			public static class MauiProgram
			{
				public static MauiApp CreateMauiApp()
				{
				}
			}
			""";

        await TestHelper.Verify(source);
    }

    [Fact]
    public async Task AutoDependencies_UseAutoDependencies_GenertateCode()
    {
        // Arrange
        const string source = """
			namespace DemoProject;

			[UseAutoDependencies]
			public static class MauiProgram
			{
				public static MauiApp CreateMauiApp()
				{
				}
			}
			""";

        await TestHelper.Verify(source);
    }
}
