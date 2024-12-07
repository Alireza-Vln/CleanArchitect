using System.Reflection;
using Xunit.Sdk;

namespace SalesSystem.TestTools.Infrastructure.DummyData;

public class FakeDate : DataAttribute
{
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        return new[] { new object[] { new DateTime(2020,1,1) } };
    }
}