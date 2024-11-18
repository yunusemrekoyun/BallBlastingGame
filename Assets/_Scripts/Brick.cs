using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {
    


    public Gradient gradient;
    private SpriteRenderer brickRenderer;

    public int brickHealth;
    private Text brickHealthText;

    private SoundManager sound;
    public GameObject brickDestroyParticle;

    // Use this for initialization
    void Start () {
        brickHealth = GameManager.level;
        brickRenderer = GetComponent<SpriteRenderer>();
        brickRenderer.color = gradient.Evaluate(1 / ((float)brickHealth + 0.5f));

        brickHealth = GameManager.level;
        brickHealthText = GetComponentInChildren<Text>();

        sound = FindObjectOfType<SoundManager>();
    }

    private void Update() {
        brickHealthText.text = "" + brickHealth;
        if (brickHealth < 1) {
            //Destroy Brick
            Destroy(this.gameObject);            
            Instantiate(brickDestroyParticle, transform.position, Quaternion.identity);            
        }
    }    
   
    private void TakeDamage(int damage) {
        brickHealth -= damage;
        brickRenderer.color = gradient.Evaluate(1/((float)brickHealth+0.5f));
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Ball") {
            sound.HitSound();
            TakeDamage(1);
        }    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "PowerUp") {
            TakeDamage(1);
        }
    }

}
