using NUnit.Framework;
using UnityEngine;
using Tempest.VFX;

public class VFXManagerTests
{
    private GameObject _vfxGo;
    private VFXManager _vfxManager;

    [SetUp]
    public void Setup()
    {
        _vfxGo = new GameObject("VFXManager");
        _vfxManager = _vfxGo.AddComponent<VFXManager>();
    }

    [Test]
    public void VFXManager_Initializes_Correctly()
    {
        Assert.IsNotNull(_vfxManager);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_vfxGo);
    }
}