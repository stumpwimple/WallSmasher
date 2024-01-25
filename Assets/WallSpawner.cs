using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {
    public GameObject wallCube;
    public int wallWidth;
    public int wallHeight;

    public float cubeWidth;

	// Use this for initialization
	void Start() { 
        cubeWidth = wallCube.transform.GetChild(0).localScale.x+.01f;
        int wallGridWidth = (int)(wallWidth / cubeWidth);
        int wallGridHeight = (int)( wallHeight / cubeWidth);
        Debug.Log(cubeWidth);


        GameObject endBrick = Instantiate(wallCube, new Vector3(-1 * cubeWidth - wallWidth / 2,wallHeight/2f, 10f), Quaternion.identity);
        endBrick.transform.parent = this.transform;
        endBrick.transform.GetChild(0).transform.localScale = new Vector3(endBrick.transform.localScale.x, wallHeight, cubeWidth*3f);
        endBrick.GetComponentInChildren<Rigidbody>().isKinematic = true;

        for (int x = 0; x < wallGridWidth; x++)
        {
            for(int y = 0; y < wallGridHeight; y++)
            {
                GameObject brick = Instantiate(wallCube, new Vector3(x*cubeWidth-wallWidth/2, y*cubeWidth+cubeWidth/2, 10f), Quaternion.identity);
                brick.transform.parent = this.transform;
                brick.transform.localScale = new Vector3(brick.transform.localScale.x, brick.transform.localScale.y, brick.transform.localScale.z+(wallGridHeight-y)*.1f);
            }
        }
        GameObject endBrick2 = Instantiate(wallCube, new Vector3(wallGridWidth * cubeWidth - wallWidth / 2, wallHeight / 2f, 10f), Quaternion.identity);
        endBrick2.transform.parent = this.transform;
        endBrick2.transform.GetChild(0).transform.localScale = new Vector3(endBrick2.transform.localScale.x, wallHeight, cubeWidth * 3f);
        endBrick2.GetComponentInChildren<Rigidbody>().isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
