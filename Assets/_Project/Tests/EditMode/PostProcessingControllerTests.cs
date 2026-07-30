using NUnit.Framework;
using UnityEngine;
using Tempest.VFX;

public class PostProcessingControllerTests
{
    private GameObject _postGo;
    private PostProcessingController _postController;

    [SetUp]
    public void Setup()
    {
        _postGo = new GameObject("PostProcessingController");
        _postController = _postGo.AddComponent<PostProcessingController>();
    }

    [Test]
    public void PostProcessingController_Initializes_Correctly()
    {
        Assert.IsNotNull(_postController);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_postGo);
    }
}