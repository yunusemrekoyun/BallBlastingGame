using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraBallPowerup : MonoBehaviour {
    
    private BallController ballController;
	
	void Start () {
        ballController = FindObjectOfType<BallController>();
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball"|| other.gameObject.tag == "Extra Ball") {
            //add an extra ball to the count
            ballController.extraBallPowerup++; 
            Destroy(this.gameObject);
        }        
    }
}
