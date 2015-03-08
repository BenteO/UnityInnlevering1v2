using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitialVelocity = 400f;

	private Rigidbody rb;
	private bool ballInPlay;

	// Use this for initialization
	void Awake () {
	
        // hämtar komponenten rigidbody som vi ska jobba med
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1") && ballInPlay == false) {
			// Ball inte längre parent av paddle
            transform.parent = null;
			ballInPlay = true;
			// slår av kinematic
            rb.isKinematic = false;
			// Kraften som bollen slungas iväg med
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
		} 
	}
}
