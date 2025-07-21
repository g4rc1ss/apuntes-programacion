using System;
using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace CreateDiscovery;

[Generator]
public class CreateDiscoveryGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        Console.WriteLine("CreateDiscoveryGenerator");

        context.SyntaxProvider.CreateSyntaxProvider<object>(
            (node, token) =>
            {
                return default;
            },
            (syntaxContext, token) =>
            {
                return default;
            }
        );
    }
}
