using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseColllider : MonoBehaviour {
    public GameObject wall;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Wall Collided");
        foreach (Rigidbody rb in wall.GetComponentsInChildren<Rigidbody>())
        {
            Debug.Log(rb.name);
            //rb.isKinematic = false;
            rb.useGravity = true;
        }

    }
}
