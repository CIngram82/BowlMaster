using UnityEngine;

public class LaneBox : MonoBehaviour {
    private PinCounter pinCounter;
    private void Start()
    {
        pinCounter = FindObjectOfType<PinCounter>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
           pinCounter.ballLeftBox = true;
        }
    }
}
