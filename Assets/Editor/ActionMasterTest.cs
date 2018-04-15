using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster actionMaster;
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnEndTurn()
    {
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
}