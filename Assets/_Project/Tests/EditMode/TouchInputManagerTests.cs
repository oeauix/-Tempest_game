using NUnit.Framework;
using UnityEngine;
using Tempest.UI;

public class TouchInputManagerTests
{
    private GameObject _touchGo;
    private TouchInputManager _touchManager;

    [SetUp]
    public void Setup()
    {
        _touchGo = new GameObject("TouchInputManager");
        _touchManager = _touchGo.AddComponent<TouchInputManager>();
    }

    [Test]
    public void TouchInputManager_Initializes_Correctly()
    {
        Assert.IsNotNull(_touchManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_touchGo);
    }
}