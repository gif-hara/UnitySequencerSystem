using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis;
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
            var attributeType = typeof(GenerateResolverAttribute);
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var i in assembly.GetTypes())
            {
                if (i.GetCustomAttribute(attributeType) != null)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"using {i.Namespace};");
                    sb.AppendLine("namespace UnitySequencerSystem.Resolvers");
                    sb.AppendLine("{");
                    sb.AppendLine($"    public abstract class {i.Name}Resolver : IResolver<{i.Name}>");
                    sb.AppendLine("    {");
                    sb.AppendLine("        public abstract void Resolve(Container container);");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("        ");
                    sb.AppendLine("    }");
                    sb.AppendLine("}");
                    sb.AppendLine("");
                    sb.AppendLine("");
                    sb.AppendLine("");
                    context.AddSource($"{i.Name}Resolver.g.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
                }
            }
        }
    }
}