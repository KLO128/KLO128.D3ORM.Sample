using System.Reflection;

namespace KLO128.Tests
{
    public class TestCase
    {
        public object?[] Args { get; set; } = null!;

        public object? ExpectedResult { get; set; } = null!;

        public object? MockService { get; set; }

        public MethodInfo? Function { get; set; }

        public string Name { get; set; } = null!;
    }
}
