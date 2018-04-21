using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinSetter : MonoBehaviour {
    public GameObject pinHolder;
    private PinCounter pinCounter;
    private Animator animator;
    
    private void Start()
    {
        pinCounter = FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
    }
 
    public void AnimationCall(ActionMaster.Action action)
    {

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("TODO : set up to end game");
        }

    }
    private void RaisePins()
    {
        foreach (Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            bowlingPin.Raise();
           
        }
    }
    private void LowerPins()
    {
        foreach (Pins bowlingPin in FindObjectsOfType<Pins>())
        {
            bowlingPin.Lower();
        }
    }
    private void RenewPins()
    {
        Destroy(GameObject.FindGameObjectWithTag("PinHolder"));
        Instantiate(pinHolder, new Vector3(0, 45, 1829),  Quaternion.identity);
    }
}
