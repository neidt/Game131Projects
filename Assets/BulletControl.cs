using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    private Rigidbody2D myRigidbody;
    public float startForce = 1000;
    public float minVelocityBeforeDestroy = 0.1f;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.AddForce(transform.up * startForce);
    }
	
	// Update is called once per frame
	void Update () {

        if (myRigidbody.velocity.magnitude < minVelocityBeforeDestroy)
        {
            Destroy(gameObject);
        }

	}
}
