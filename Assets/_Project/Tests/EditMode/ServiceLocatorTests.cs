using NUnit.Framework;
using Tempest.Core;

public class ServiceLocatorTests
{
    [SetUp]
    public void Setup()
    {
        ServiceLocator.Clear();
    }

    [Test]
    public void Register_And_Resolve_Service_Successfully()
    {
        var testService = new TestService();
        ServiceLocator.Register(testService);

        var resolved = ServiceLocator.Resolve<TestService>();
        Assert.AreEqual(testService, resolved);
    }

    [Test]
    public void Resolve_Unregistered_Service_ThrowsException()
    {
        Assert.Throws<System.Exception>(() => ServiceLocator.Resolve<TestService>());
    }

    private class TestService { }
}