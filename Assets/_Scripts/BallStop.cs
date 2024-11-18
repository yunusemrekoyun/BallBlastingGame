using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStop : MonoBehaviour {
        
    private BallController ballControl;
    private int counter;

    private bool firstball;

	private void Start () {
        firstball = true;
        ballControl = FindObjectOfType<BallController>();
	}
    private void Update() {
        if(counter == ballControl.numOfBalls) {
            firstball = true;
            counter = 0;
            ballControl.currentBallState = ballState.NEXTLEVEL;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ball"){         
            
            if(firstball) {
                firstball = false;              
                other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Vector3 point = other.transform.position;
                point.y = -3.85f;
                ballControl.transform.position = point;
                Destroy(other.gameObject);
            } else {
                Destroy(other.gameObject);
            }      
            counter++;
        }
        
    }
}
