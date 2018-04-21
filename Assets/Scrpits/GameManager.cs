using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private ScoreDisplay scoreDisplay;
    private PinSetter pinSetter;
    private Ball ball;
    private List<int> pinFalls = new List<int>();


    // Use this for initialization
    void Start () {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
    }

    public void Bowl(int pinfall)
    {
        pinFalls.Add(pinfall);
        ball.Reset();
        pinSetter.AnimationCall(ActionMaster.NextAction(pinFalls));
        scoreDisplay.FillRolls(pinFalls);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(pinFalls));
    }
}
