using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {
    
    private BallController ball;
    public GameObject endGamePanel;


	// Use this for initialization
	void Start () {
        ball = FindObjectOfType<BallController>();
        endGamePanel.SetActive(false);
        	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Square Brick" || other.gameObject.tag == "Triangle Brick01" || other.gameObject.tag == "Triangle Brick02" ||
            other.gameObject.tag == "Triangle Brick03" || other.gameObject.tag == "Triangle Brick04") {
            ball.currentBallState = ballState.ENDGAME;
            endGamePanel.SetActive(true);
        } else if (other.gameObject.tag == "Extra Ball Powerup") {
            Destroy(other.gameObject);
        }

    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
