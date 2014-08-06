namespace lasl321.simpleinjector.test
{
    internal class ADependency : IADependency
    {
        public string ReturnString()
        {
            return "This is a dependency 123";
        }
    }
}