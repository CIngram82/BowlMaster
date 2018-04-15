using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {
    private Ball ball;
    private Vector3 offset;

	void Start () {
        ball = FindObjectOfType<Ball>();
        offset = transform.position - ball.transform.position;
	}
	
	void Update () {
        if(ball.transform.position.z <= 1829)
        {
            transform.position = ball.transform.position + offset;
        }
	}
}
