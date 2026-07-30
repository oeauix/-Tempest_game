using NUnit.Framework;
using UnityEngine;
using Tempest.UI;

public class UIManagerTests
{
    private GameObject _uiGo;
    private UIManager _uiManager;

    [SetUp]
    public void Setup()
    {
        _uiGo = new GameObject("UIManager");
        _uiManager = _uiGo.AddComponent<UIManager>();
    }

    [Test]
    public void UIManager_CanTogglePause()
    {
        _uiManager.TogglePauseMenu();
        Assert.Pass();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_uiGo);
    }
}