using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace lasl321.simpleinjector.test
{
    public class SimpleInjectorRegistrationTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container();
            _container.RegisterPackages<PackageAssemblies>();
        }

        [Test]
        public void ShouldReturnDependencyString()
        {
            var instance = _container.GetInstance<ISomethingThatHasDependency>();

            Assert.That(instance.CallDependency(), Is.EqualTo("This is a dependency 123"));
        }
    }

    public class Package : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ISomethingThatHasDependency, SomethingThatHasDependency>();
            container.Register<IADependency, ADependency>();
        }
    }

    public class PackageAssemblies : IEnumerable<Assembly>
    {
        public IEnumerator<Assembly> GetEnumerator()
        {
            yield return GetType().Assembly;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}