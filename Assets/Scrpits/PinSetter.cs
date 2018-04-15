using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public Text pinCountTextBox;
    public int lastStandingCount = -1;
    public GameObject pinHolder;
    
    private Ball ball;
    private bool ballEteredBox = false;
    private float lastChangeTime = 0;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
    void Update () {
        if (ballEteredBox)
        {
            UpdateStandingCountAsPinsSettle();

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
        pinCountTextBox.color = Color.green;
        ballEteredBox = false;
        lastStandingCount = -1;
        ball.Reset();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballEteredBox = true;
            pinCountTextBox.color= Color.red;
        }
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
