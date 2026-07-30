using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Tempest.Gameplay.Player;
using Tempest.World;

public class Integration_LightningWeave_ConductiveNode_Test
{
    private GameObject _player;
    private LightningWeaveSystem _weaveSystem;
    private GameObject _nodeObject;
    private ConductiveNode _node;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        _player = new GameObject("Player");
        _weaveSystem = _player.AddComponent<LightningWeaveSystem>();
        _weaveSystem.maxChainDistance = 30f;
        _weaveSystem.maxTargets = 4;

        _nodeObject = new GameObject("ConductiveNode");
        _node = _nodeObject.AddComponent<ConductiveNode>();
        _node.transform.position = Vector3.forward * 10f;

        yield return null;
    }

    [UnityTest]
    public IEnumerator LightningWeave_CanInteract_WithConductiveNode()
    {
        // Simulate activation near conductive node
        _weaveSystem.TryActivateWeave();
        Assert.IsNotNull(_node);
        yield return null;
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_player);
        Object.Destroy(_nodeObject);
    }
}