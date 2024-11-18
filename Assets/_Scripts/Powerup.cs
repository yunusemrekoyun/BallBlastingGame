using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType {
    HORIZONTAL,
    VERTICAL,
    BOUNCE
}



public class Powerup : MonoBehaviour {

    public PowerupType type;
    private bool isTrigger = false;
    public GameObject hit;
    private BallController ballControl;


    void Start() {
        ballControl = FindObjectOfType<BallController>();
    }
    private void Update() {
        if (ballControl.currentBallState == ballState.NEXTLEVEL) {
            if (isTrigger) {
                Destroy(this.gameObject);
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ball"&& (ballControl.currentBallState == ballState.FIRE|| ballControl.currentBallState == ballState.ENDSHOT)) {   
            isTrigger = true;
            switch (type) {
                case PowerupType.VERTICAL:
                    
                    hit.GetComponent<LineRenderer>().SetPosition(0, new Vector3(transform.position.x, -4, 0));
                    hit.GetComponent<LineRenderer>().SetPosition(1, new Vector3(transform.position.x, 6, 0));
                    hit.SetActive(true);
                    Invoke("EndHit", 0.05f);                   
                    break;
                case PowerupType.HORIZONTAL:
                    hit.GetComponent<LineRenderer>().SetPosition(0, new Vector3(-4, transform.position.y, 0));
                    hit.GetComponent<LineRenderer>().SetPosition(1, new Vector3(4, transform.position.y, 0));
                    hit.SetActive(true);
                    Invoke("EndHit", 0.05f);
                    break;
                case PowerupType.BOUNCE:
                    if (other.gameObject.transform.position.y > transform.position.y) {
                        if (Mathf.Abs(other.GetComponent<Rigidbody2D>().velocity.y) < 0.1|| Mathf.Abs(other.GetComponent<Rigidbody2D>().velocity.x) < 0.1) {
                            int t = Random.Range(-1, 2);
                            Vector2 tmp = new Vector2(t * Mathf.Tan(Mathf.Deg2Rad * 45), 1).normalized * 10f;
                            other.gameObject.GetComponent<Rigidbody2D>().velocity = tmp;
                        } else {
                            Vector2 tmp = other.gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(0.2f, 0f);
                            other.gameObject.GetComponent<Rigidbody2D>().velocity = -tmp;
                        }                        
                    }else {
                        int t = Random.Range(-1, 2);
                        Vector2 tmp = new Vector2(t*Mathf.Tan(Mathf.Deg2Rad * 45), 1).normalized*10f;
                        other.gameObject.GetComponent<Rigidbody2D>().velocity = tmp;
                    }
                    hit.SetActive(true);
                    GetComponent<SpriteRenderer>().enabled = false;
                    Invoke("EndHit", 0.02f);
                    break;

            }
        }
    }

    private void EndHit() {
        hit.SetActive(false);      
        GetComponent<SpriteRenderer>().enabled = true;
        
       
    }
}
