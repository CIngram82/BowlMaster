using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody myRigidbody;
    private AudioSource audioSource;
    public Vector3 launchVelocity;
    public bool isLaunched = false;
    private Vector3 startPos;
    private Quaternion startRot;


    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;

        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void Launch(Vector3 velocity)
    {
        isLaunched = true;
        myRigidbody.useGravity = true;
        myRigidbody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        isLaunched = false;
        myRigidbody.useGravity = false;
        transform.position = startPos;
        transform.rotation = startRot;
        myRigidbody.velocity = Vector3.zero;
        myRigidbody.angularVelocity = Vector3.zero;
    }
}
