using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {
    public float standingThreshold = 6f;
    public float distanceToRaise = 45f;
    private Rigidbody myRigidbody;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if ((tiltInX > 360 - standingThreshold  || tiltInX < standingThreshold) &&
            (tiltInZ > 360 - standingThreshold) || tiltInZ < standingThreshold)
        {
            return true;
        }else{
            return false;
        }
    }
    public void Raise()
    {
        if (IsStanding())
        {
            myRigidbody.useGravity = false;
            myRigidbody.isKinematic = true;
            transform.Translate(0, distanceToRaise, 0);
        }
    }

    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(0,-distanceToRaise, 0);
            myRigidbody.useGravity = true;
            myRigidbody.isKinematic = false;
        }  
    }
}
