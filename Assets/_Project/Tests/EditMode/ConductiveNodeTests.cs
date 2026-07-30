using NUnit.Framework;
using UnityEngine;
using Tempest.World;

public class ConductiveNodeTests
{
    private GameObject _nodeObject;
    private ConductiveNode _node;

    [SetUp]
    public void Setup()
    {
        _nodeObject = new GameObject("ConductiveNode");
        _node = _nodeObject.AddComponent<ConductiveNode>();
        _node.energyStored = 100f;
    }

    [Test]
    public void ConductiveNode_InitialState_IsActive()
    {
        Assert.IsTrue(_node.isActive);
    }

    [Test]
    public void ActivateNode_DeactivatesNode()
    {
        _node.ActivateNode();
        Assert.IsFalse(_node.isActive);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_nodeObject);
    }
}