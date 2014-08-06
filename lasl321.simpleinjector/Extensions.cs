using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleInjector;

namespace lasl321.simpleinjector
{
    public static class Extensions
    {
        public static void RegisterPackageAssemblies(this Container container)
        {
            var packageAssemblies = Assembly.GetCallingAssembly()
                                            .ExportedTypes
                                            .Where(x => x.Name == "PackageAssemblies")
                                            .Select(Activator.CreateInstance)
                                            .Cast<IEnumerable<Assembly>>()
                                            .DefaultIfEmpty(Enumerable.Empty<Assembly>())
                                            .First();

            container.RegisterPackages(packageAssemblies);
        }
    }
}