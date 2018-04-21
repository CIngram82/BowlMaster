/*
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }
    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void T01Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }
    
    [Test]
    public void T03EndOfFrameReturnsEndTurn()
    {
        pinFalls.Add(8);
        pinFalls.Add(1);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    
    [Test]
    public void T05OneStrikeReturnEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    
  [Test]
  public void T07Bowl28SpareReturnsEndTurn()
  {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
        pinFalls.Add(2);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
  }
  [Test]
  public void T08CheckResetAtStrikeInLastFrame()
  {
    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10 };
    Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
  }
   
  [Test]
  public void T09CheckResetAtSpareInLastFrame()
  {
    int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,9 };
    Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T10YouTubeEndGame()
  {
    int[] rolls = { 8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2,1 };
    Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
  }
  
  [Test]
  public void T11GameEndsLastFrameScore02()
  {
    int[] rolls = { 1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1 ,1,1};
    Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T12TidyAfterLastFrameScoreStrikeand5()
  {
      int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,5 };
      Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T13TidyAfterLastFrameScoreStrikeandGutterBall()
  {
      int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,10,0};
      Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T14TwoStrikesLastFrameResets()
  {
      int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,10 };
      Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T15ThreeStrikesLastFrameEndsGame()
  {
      int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,10,10,10 };
      Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
  }
    
  [Test]
  public void T16SpareOf0And10NextBowlofNot10IsTidy()
  {
        pinFalls.Add(0);
        pinFalls.Add(10);
        pinFalls.Add(5);
      Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
  }
    
  [Test]
  public void T17SpareOf0And10NextBowlof10IsEndTurn()
  {
        pinFalls.Add(0);
        pinFalls.Add(10);
        pinFalls.Add(10);
      Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
  }
  
}*/