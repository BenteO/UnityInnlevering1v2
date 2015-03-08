using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {
	
	public int lives = 3;
	public int bricks = 176;
    //How long before the paddle respawns
    public float resetDelay = 1f;
    // Räknar poäng
    public int points = 0;
    public Text pointsText;
    public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;
	
	private GameObject clonePaddle;
    public GameObject bonusItem;
	
	// Use this for initialization, checks if there is an existing game and destroys it
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

        // Kallar på metoden som startar spelet och spawnar paddle och bricks
		Setup();
		
	}
	
	// Spawnar paddle och bricks
	public void Setup()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, transform.position, Quaternion.identity);
	}
	
	// Checks if you won the game or not
	void CheckGameOver()
	{
		if (bricks < 1) // You won
		{
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
		if (lives < 1) // You lose
		{
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		
	}
	
	// Starts the level again
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}
	
	// Keeps score of number of lives
	public void LoseLife()
	{
		lives--;
		livesText.text = "Lives: " + lives;
		
		// Destroys paddle
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		
		// Spawns the paddle again
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver();
	}
	
	// Spawns the paddle after death
	void SetupPaddle()
	{
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}
	
	public void DestroyBrick()
	{
		bricks--;
        if (bricks == 170)
        {
            Instantiate(bonusItem, transform.position, Quaternion.identity);
        }
		CheckGameOver();
	}

    // Metod för att räkna poäng
    public void Points()
    {
        points++;
        pointsText.text = "Points: " + points;
    }
}