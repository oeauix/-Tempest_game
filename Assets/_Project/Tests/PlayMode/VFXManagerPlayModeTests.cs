using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.VFX;

public class VFXManagerPlayModeTests
{
    private GameObject _vfxGo;
    private VFXManager _vfxManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _vfxGo = new GameObject("VFXManager");
        _vfxManager = _vfxGo.AddComponent<VFXManager>();
        yield return null;
    }

    [UnityTest]
    public IEnumerator VFXManager_CanPlayLightningBolt()
    {
        _vfxManager.PlayLightningBolt(Vector3.zero, Vector3.forward * 5f);
        Assert.IsNotNull(_vfxManager);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_vfxGo);
    }
}