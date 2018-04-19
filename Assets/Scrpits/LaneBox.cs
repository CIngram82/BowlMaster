using UnityEngine;

public class LaneBox : MonoBehaviour {
    private PinSetter pinSetter;
    private void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
           pinSetter.ballLeftBox = true;
        }
    }
}
