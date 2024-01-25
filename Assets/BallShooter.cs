using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallShooter : MonoBehaviour {
    public GameObject projectile;
    public Slider powerSlider, xRotationSlider, yRotationSlider;

    private GameObject cannon;
    private GameObject projectileHolder;

    public GameObject barrel;
	// Use this for initialization
	void Start () {
        cannon = GetComponentInChildren<Cannon>().gameObject;
        projectileHolder = GameObject.Find("Projectiles");
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotationSlider.value, transform.eulerAngles.z);
        cannon.transform.eulerAngles = new Vector3(xRotationSlider.value, cannon.transform.eulerAngles.y, cannon.transform.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }

        if (Input.GetKey(KeyCode.A))
        {
            yRotationSlider.value -= .5f;
        } else if (Input.GetKey(KeyCode.D))
        {
            yRotationSlider.value += .5f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            xRotationSlider.value -= .5f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            xRotationSlider.value += .5f;
        }
    }

    void Fire() {
        GameObject bullet = Instantiate(projectile, barrel.transform.position, barrel.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = barrel.transform.rotation*Vector3.up*powerSlider.value;
        bullet.transform.parent = projectileHolder.transform;
    }

}
