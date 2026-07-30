using NUnit.Framework;
using UnityEngine;
using Tempest.Gameplay.Player;

public class CameraControllerTests
{
    private GameObject _cameraGo;
    private PlayerCameraController _cameraController;

    [SetUp]
    public void Setup()
    {
        _cameraGo = new GameObject("Camera");
        _cameraController = _cameraGo.AddComponent<PlayerCameraController>();
    }

    [Test]
    public void CameraController_Initializes_Correctly()
    {
        Assert.IsNotNull(_cameraController);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_cameraGo);
    }
}