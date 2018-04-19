using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    private ScoreDisplay scoreDisplay;
    private GameManager gameManager;

    public bool ballLeftBox = false;
    private int lastSettledCount = 10;

    private float lastChangeTime = 0;
    private int lastStandingCount = -1;

    void Start () {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        gameManager = FindObjectOfType<GameManager>();
    }
	
	void Update () {
        if (ballLeftBox)
        {
            UpdateStandingCountAsPinsSettle();
            scoreDisplay.UpdateText(Color.red, CountStanding().ToString());
        }else
        {
            scoreDisplay.UpdateText(Color.green, CountStanding().ToString());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            ballLeftBox = true;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }
    void UpdateStandingCountAsPinsSettle()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - lastChangeTime) > settleTime)
        {
            PinsHaveSettled();
        }
    }
    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;
        ballLeftBox = false;
        lastStandingCount = -1;

        gameManager.Temp(pinFall);
    }
    int CountStanding()
    {
        int numStandingPins = 0;
        foreach (Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            if (bowlingPin.IsStanding())
            {
                numStandingPins++;
            }
        }
        return numStandingPins;
    }
}
