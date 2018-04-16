using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endGame = ActionMaster.Action.Endgame;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }
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
        actionMaster.Bowl(8);
        Assert.AreEqual(8, actionMaster.bowls[0]);
    }
    [Test]
    public void T03EndOfFrameReturnsEndTurn()
    {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(1));
    }
    [Test]
    public void T05OneStrikeReturnEndTurn()
    {
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    [Test]
    public void T07Bowl28SpareReturnsEndTurn()
    {
        Assert.AreEqual(tidy, actionMaster.Bowl(2));
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }
    [Test]
    public void T08CheckResetAtStrikeInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach(int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }
    [Test]
    public void T09CheckResetAtSpareInLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(reset, actionMaster.Bowl(9));
    }
    [Test]
    public void T10YouTubeEndGame()
    {
        int[] rolls = { 8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
     
        Assert.AreEqual(endGame, actionMaster.Bowl(9));
    }
    [Test]
    public void T11GameEndsLastFrameScore02()
    {
        int[] rolls = { 1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(0);
        Assert.AreEqual(endGame, actionMaster.Bowl(2));
    }
    [Test]
    public void T12TidyAfterLastFrameScoreStrikeand5()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }
    [Test]
    public void T13TidyAfterLastFrameScoreStrikeandGutterBall()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(0));
    }
    [Test]
    public void T14TwoStrikesLastFrameResets()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }
    [Test]
    public void T15ThreeStrikesLastFrameEndsGame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        foreach (int roll in rolls)
        {
            actionMaster.Bowl(roll);
        }
        actionMaster.Bowl(10);
        actionMaster.Bowl(10);
        Assert.AreEqual(endGame, actionMaster.Bowl(10));
    }
    [Test]
    public void T16SpareOf0And10NextBowlofNot10IsTidy()
    {
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }
    [Test]
    public void T17SpareOf0And10NextBowlof10IsEndTurn()
    {
        actionMaster.Bowl(0);
        actionMaster.Bowl(10);
        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
}