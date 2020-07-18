using System.IO.Abstractions;
using Lamar;
using StructureMap;

namespace Mmu.Wb.TimeBuddy.WpfUI.Infrastructure.DependencyInjection
{
    public class WpfUiRegistryCollection : ServiceRegistry
    {
        public WpfUiRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WpfUiRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}