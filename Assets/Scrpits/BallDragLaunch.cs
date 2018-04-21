using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    


	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;
    
        float dragTime = endTime - startTime;
        float launchSpeedx = (dragEnd.x - dragStart.x)/dragTime;
        float launchSpeedz = (dragEnd.y - dragStart.y)/dragTime;
        launchSpeedz = Mathf.Abs(launchSpeedz); // stops ball from going back. TODO find better way 


        Vector3 launceVec3 = new Vector3(launchSpeedx,0,launchSpeedz);
        if (!ball.isLaunched)
        {
            ball.Launch(launceVec3);
            ball.isLaunched = true;
        }
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.isLaunched)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + xNudge,-50f,50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
}
