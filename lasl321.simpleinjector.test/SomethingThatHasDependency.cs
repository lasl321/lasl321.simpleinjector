namespace lasl321.simpleinjector.test
{
    internal class SomethingThatHasDependency : ISomethingThatHasDependency
    {
        private readonly IADependency _dependency;

        public SomethingThatHasDependency(IADependency dependency)
        {
            _dependency = dependency;
        }

        public string CallDependency()
        {
            return _dependency.ReturnString();
        }
    }
}