using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinSetter : MonoBehaviour {
    public Text pinCountTextBox;
    public GameObject pinHolder;

    public bool ballLeftBox = false;

    private List<int> pinFalls;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime = 0;
    private ActionMaster actionMaster = new ActionMaster();

    private Animator animator;
    private Ball ball;

    private void Start()
    {
        animator = GetComponent<Animator>();
        ball = FindObjectOfType<Ball>();
    }
    void Update () {
        if (ballLeftBox)
        {
            UpdateStandingCountAsPinsSettle();
            pinCountTextBox.color = Color.red;
            pinCountTextBox.text = CountStanding().ToString();
        }
    }

    void UpdateStandingCountAsPinsSettle()
    {
        int currentStanding = CountStanding();

        if(currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        AnimationCall(pinFall);
        

        pinCountTextBox.color = Color.green;
        ballLeftBox = false;
        lastStandingCount = -1;
       
        ball.Reset();
    }
    private void AnimationCall(int pinFall)
    {
        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        } else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Endgame)
        {
            throw new UnityException("TODO : set up to end game");
        }

    }

    int CountStanding()
    {
        int numStandingPins = 0;
        foreach(Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            if (bowlingPin.IsStanding()){
                numStandingPins++;
            }
        }
        return numStandingPins;
    }



    public void RaisePins()
    {
        foreach (Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            bowlingPin.Raise();
           
        }
    }
    public void LowerPins()
    {
        foreach (Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            bowlingPin.Lower();
        }
    }
    public void RenewPins()
    {
        Instantiate(pinHolder, new Vector3(0, 45, 1829),  Quaternion.identity);
    }
}
