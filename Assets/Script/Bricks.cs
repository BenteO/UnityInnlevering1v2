using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {
	
	public GameObject brickParticle;
	
	void OnCollisionEnter (Collision other)
	{
        // Vid kollision spawnas brickParticle, två andra är position
		Instantiate(brickParticle, transform.position, Quaternion.identity);
		// Kallar på metoden som räknar ner bricks och kollar om vi vunnit eller ej
        GM.instance.DestroyBrick();
		// Förstör gameobject
        Destroy(gameObject);
	}
}