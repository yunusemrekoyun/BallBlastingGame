using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickMoveController : MonoBehaviour {

    private GameManager gameManager;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void BricksMove() {
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        gameManager.BrickMove();
        gameManager.PlaceBricks();
    }


}
