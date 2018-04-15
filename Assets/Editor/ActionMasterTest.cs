using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster = new ActionMaster();
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;



    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void T01Bowl8ReturnsTidy()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }
    [Test]
    public void T02CheckScoreofFirstBowlReturns8()
    {
        Assert.AreEqual(8, actionMaster.bowls[0]);
    }
    [Test]
    public void T03EndOfFrameReturnsEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }
    [Test]
    public void T04CheckScoreAfterFirstFrameReturns9()
    {
        Assert.AreEqual(9, actionMaster.frames[0]);
    }
    [Test]
    public void T05OneStrikeReturnEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    [Test]
    public void T06Bowl28SpareReturnsEndTurn()
    {
        Assert.AreEqual(tidy,    actionMaster.Bowl(2));
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }
    [Test]
   
    public void T07CheckScoreof()
    {

    }
}