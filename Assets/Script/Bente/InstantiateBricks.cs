using UnityEngine;
using System.Collections;

public class InstantiateBricks : MonoBehaviour {

	public GameObject brick;

	// Use this for initialization
	void Start () {
		for (int i = 0; i <=29; i++) {
			brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
			brick.AddComponent<Rigidbody>();
			brick.transform.position = new Vector3(i, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
