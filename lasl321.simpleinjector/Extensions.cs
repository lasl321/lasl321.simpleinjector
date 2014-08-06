using System.Collections.Generic;
using System.Reflection;
using SimpleInjector;

namespace lasl321.simpleinjector
{
    public static class Extensions
    {
        public static void RegisterPackages<T>(this Container container) where T : IEnumerable<Assembly>, new()
        {
            container.RegisterPackages(new T());
        }
    }
}