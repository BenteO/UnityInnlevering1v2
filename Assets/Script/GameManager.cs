using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public int nrOfLives = 3;
	public int nrOfBricks = 215;
    public int points = 0;

    public float resetDelay = 1f;

    public Text pointsText;
    public Text livesText;
	
    public GameObject youLose;
	public GameObject youWon;
	public GameObject bricks;
	public GameObject paddle;
	public GameObject deathParticles;
    public GameObject bonusItem;

    public static GameManager instance = null;
	
	private GameObject clonePaddle;
	
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
		Instantiate(bricks, transform.position, Quaternion.identity);
	}
	
	// Checks if you won the game or not
	void CheckGameOver()
	{
        if (nrOfBricks < 1) // You won
		{
			youWon.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
		}

        if (nrOfLives < 1) // You lose
		{
            youLose.SetActive(true);
                Time.timeScale = .25f;
                Invoke("Reset", resetDelay);
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
        nrOfLives--;
        livesText.text = "Lives: " + nrOfLives;
		
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
        nrOfBricks--;
        if (nrOfBricks == 200 || nrOfBricks == 180 || nrOfBricks == 160 || nrOfBricks == 140 || nrOfBricks == 100 || nrOfBricks == 80 || nrOfBricks == 60 || nrOfBricks == 40 || nrOfBricks == 00)
        {
            Instantiate(bonusItem, transform.position, Quaternion.identity);
            CheckGameOver();
        } 
	}

    // Metod för att räkna poäng
    public void Points()
    {
        points++;
        pointsText.text = "Points: " + points;
    }
}