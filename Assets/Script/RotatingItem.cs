using UnityEngine;
using System.Collections;

public class RotatingItem : MonoBehaviour {

	void Update () {
		gameObject.transform.Rotate(1, 1, 0);
	}
}
