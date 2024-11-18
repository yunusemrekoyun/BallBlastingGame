using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    public Transform[] SpawnPos;
    public GameObject[] Bricks;
    public GameObject[] Powerup;
    public GameObject extraBallPowerup;

    public static readonly int colNum = 7;
    public static readonly int rowNum = 10; 

    private ArrayList bricksArray; 

    public static int level;        

    public Transform Parent;

    public Text LevelText;


    void Start () {               
        level = 0;
        //空ArrayList
        bricksArray = new ArrayList();
        for(int row = 0; row < rowNum; row++) {            
            ArrayList tmp = new ArrayList();
            for (int col = 0; col < colNum; col++) {
                GameObject b = null;
                tmp.Add(b);
            }
            bricksArray.Add(tmp);
        }
        //放置Bricks
        PlaceBricks();
    }
    private void Update() {
        LevelText.text = "" + GameManager.level;
    }


    public void PlaceBricks() {

        level++;      
        int extraBallPos = Random.Range(0, colNum);
        GameObject extraBall = Instantiate(extraBallPowerup, SpawnPos[extraBallPos].position, Quaternion.identity);
        extraBall.transform.parent = Parent.transform;        
        SetBrick(extraBallPos, rowNum - 2, extraBall);

        for (int i = 0; i < colNum; i++) {
            if (GetBrick(i,rowNum-2) == null) {
                int brickToCreate = Random.Range(0, 10);
                if (brickToCreate <5) {
                    GameObject brick = Instantiate(Bricks[0], SpawnPos[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                    SetBrick(i, rowNum - 1, brick);
                } else if (brickToCreate == 6) {                    
                    GameObject brick = Instantiate(Bricks[Random.Range(1,5)], SpawnPos[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                    SetBrick(i, rowNum - 1, brick);                    
                } else if (brickToCreate == 7) {
                    GameObject brick = Instantiate(Powerup[Random.Range(0, 3)], SpawnPos[i].position, Quaternion.identity);
                    brick.transform.parent = Parent.transform;
                    SetBrick(i, rowNum - 1, brick);
                } 
            }
        }     
    }
    
    private GameObject GetBrick(int colIndex, int rowIndex) {
        ArrayList tmp = bricksArray[rowIndex] as ArrayList;
        GameObject c = tmp[colIndex] as GameObject;
        return c;
    }

    private void SetBrick(int colIndex, int rowIndex, GameObject c) {        
        ArrayList tmp = bricksArray[rowIndex] as ArrayList;
        tmp[colIndex] = c;
    }

    public void BrickMove() {
        for (int row = 1; row < rowNum-1; row++) {            
            for (int col = 0; col < colNum; col++) {
                GameObject b = GetBrick(col, row);
                SetBrick(col, row - 1, b);
            }            
        }
        for (int col = 0; col < colNum; col++) {
            SetBrick(col, rowNum - 1, null);
        }
    } 
    

    public void ErrorBouncePowerup(int row) {
            while (true) {
            int col = Random.Range(0, colNum);
            GameObject b = GetBrick(col, row);
            if (b == null) {
                GameObject brick =Instantiate(Powerup[2], new Vector3(col-3f, (float)row-3.5f, 0), Quaternion.identity);
                SetBrick(col, row, brick);
                return;
            }  
        }
    }
}

