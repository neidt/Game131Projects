using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowUserControl : MonoBehaviour {

    public float rotationSpeed = 90f;
    public GameObject bullet;

    private Transform bulletSpawn;

	// Use this for initialization
	void Start () {
        bulletSpawn = transform.Find("bulletSpawn");

    }
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Spawn a projectile
            GameObject newBullet = GameObject.Instantiate(bullet, bulletSpawn);
            newBullet.transform.parent = null;
        }
    }
}
