using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	//public GameObject startButton;

	public void StartGame () {
		Application.LoadLevel("Breakout");
	}

}
