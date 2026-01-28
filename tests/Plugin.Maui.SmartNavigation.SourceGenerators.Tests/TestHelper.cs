using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Plugin.Maui.SmartNavigation.SourceGenerators;
using System.Runtime.CompilerServices;

namespace IeuanWalker.MinimalApi.Endpoints.Generator.Tests;

public static class TestHelper
{
    public static Task Verify(string source, [CallerFilePath] string sourceFile = "")
    {
        // Parse the provided source code
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(source);

        // Create a compilation with the source code
        CSharpCompilation compilation = CSharpCompilation.Create(
            assemblyName: "TestAssembly",
            syntaxTrees: [syntaxTree],
            references: [],
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        // Create an instance of the source generator
        AutoDependencies generator = new();

        // Use the Roslyn driver to run the generator
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        // Run the generator
        driver = driver.RunGenerators(compilation);

        // Use Verify to snapshot test the results
        return Verifier.Verify(driver);
    }
}
