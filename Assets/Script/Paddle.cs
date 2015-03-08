using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed = 1f;

	private Vector3 playerPos = new Vector3(0f, -10f, 0f);
	

	// Update is called once per frame
	void Update () {
	
		float xPos = transform.position.x + (Input.GetAxis ("Horizontal") * paddleSpeed);
		playerPos = new Vector3 (Mathf.Clamp(xPos, -11f, 11f), -10f, 0f);
		transform.position = playerPos;
	}
}
