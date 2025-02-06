using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace UnitySequencerSystem.ResolverProject
{
    [Generator]
    public class Generator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            foreach (var syntaxTree in context.Compilation.SyntaxTrees)
            {
                var classNodes = syntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>();
                foreach (var classNode in classNodes)
                {
                    var hasAttribute = classNode.AttributeLists.Any(x => x.Attributes.Any(y => y.Name.ToString() == "GenerateResolver"));
                    if (!hasAttribute)
                    {
                        continue;
                    }
                    var model = context.Compilation.GetSemanticModel(syntaxTree);
                    var classSymbol = model.GetDeclaredSymbol(classNode);
                    var className = classSymbol.Name;
                    var nameSpaceName = classSymbol.ContainingNamespace.ToString();
                    Generate(className, nameSpaceName);
                }
                var structNodes = syntaxTree.GetRoot().DescendantNodes().OfType<StructDeclarationSyntax>();
                foreach (var structNode in structNodes)
                {
                    var hasAttribute = structNode.AttributeLists.Any(x => x.Attributes.Any(y => y.Name.ToString() == "GenerateResolver"));
                    if (!hasAttribute)
                    {
                        continue;
                    }
                    var model = context.Compilation.GetSemanticModel(syntaxTree);
                    var structSymbol = model.GetDeclaredSymbol(structNode);
                    var structName = structSymbol.Name;
                    var nameSpaceName = string.Join(".", structSymbol.ContainingNamespace.GetNamespaceMembers().Select(x => x.Name));
                    Generate(structName, nameSpaceName);
                }
            }
            void Generate(string symbolName, string nameSpaceName)
            {
                var resolverClassName = $"{symbolName}Resolver";
                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using UnityEngine;");
                sb.AppendLine($"using {nameSpaceName};");
                sb.AppendLine("namespace UnitySequencerSystem.Resolvers");
                sb.AppendLine("{");
                sb.AppendLine($"    public abstract class {resolverClassName} : UnitySequencerSystem.Resolvers.IResolver<{symbolName}>");
                sb.AppendLine("    {");
                sb.AppendLine($"        public abstract {symbolName} Resolve(Container container);");
                sb.AppendLine("        [AddTypeMenu(\"Reference\")]");
                sb.AppendLine("        [Serializable]");
                sb.AppendLine($"        public sealed class Reference : {resolverClassName}");
                sb.AppendLine("        {");
                sb.AppendLine($"            private {symbolName} target;");
                sb.AppendLine("            ");
                sb.AppendLine("            public Reference(){}");
                sb.AppendLine($"            public Reference({symbolName} target)");
                sb.AppendLine("            {");
                sb.AppendLine("                this.target = target;");
                sb.AppendLine("            }");
                sb.AppendLine("            ");
                sb.AppendLine($"            public override {symbolName} Resolve(Container container) => target;");
                sb.AppendLine("        }");
                sb.AppendLine("        [AddTypeMenu(\"Name\")]");
                sb.AppendLine("        [Serializable]");
                sb.AppendLine($"        public sealed class Name : {resolverClassName}");
                sb.AppendLine("        {");
                sb.AppendLine($"            [SerializeField]");
                sb.AppendLine($"            private string name;");
                sb.AppendLine("            ");
                sb.AppendLine("            public Name(){}");
                sb.AppendLine($"            public Name(string name)");
                sb.AppendLine("            {");
                sb.AppendLine("                this.name = name;");
                sb.AppendLine("            }");
                sb.AppendLine("            ");
                sb.AppendLine($"            public override {symbolName} Resolve(Container container) => container.Resolve<{symbolName}>(name);");
                sb.AppendLine("        }");
                sb.AppendLine("    }");
                sb.AppendLine("}");
                context.AddSource($"{symbolName}Resolver.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
            }
        }
    }
}