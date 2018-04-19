using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private PinSetter pinSetter;
    private Ball ball;
    private List<int> pinFalls = new List<int>();


    // Use this for initialization
    void Start () {
        pinSetter = FindObjectOfType<PinSetter>();
        ball = FindObjectOfType<Ball>();
    }

    public void Temp(int pinfall)
    {
        pinFalls.Add(pinfall);
        ActionMaster.Action action = ActionMaster.NextAction(pinFalls);
        pinSetter.AnimationCall(action);
        ball.Reset();
    }
}
