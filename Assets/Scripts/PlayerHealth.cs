using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerHealth : MonoBehaviour 
{
	public int startHealth = 100;
	public int currentHealth;
	public Text scoreText;
	public Text restartText;
	public Text gameOverText;
	public Text healthText;

	private bool nextlevel;
	private bool restart;
	private bool gameOver;
	private int score;
	private Gate gate;
	private float replay;

	void Start ()
	{
		currentHealth = startHealth;
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore ();

		GameObject gateObject = GameObject.FindWithTag ("Gate");
		if (gateObject != null) 
		{
			gate = gateObject.GetComponent <Gate> ();
		}

		if (gateObject = null) 
		{
			print ("Gate not found");
		}
	}

	void Update()
	{
		if (gameOver == true) 
		{
			restartText.text = "Touch Health to Restart";
			restart = true;
		}

		/*if (gameOver == false) 
		{
			gameOverText.text = "YOU WIN!!!\nCONGRATULATIONS";
		}*/

		if (restart == true) 
		{
			if (CrossPlatformInputManager.GetButton ("Replay")) 
			{
				Application.LoadLevel (Application.loadedLevel);	
				Time.timeScale = 1f;
			}
		}
	}

	void UpdateScore()
	{
		scoreText.text = "Score:" + score;	
		healthText.text = "Health:" + currentHealth;

		if (currentHealth <= 0) 
		{
			GameOver ();
			Time.timeScale = 0f;
		}
	}

	public void AddScore ()
	{
		score += 10;
		UpdateScore ();
	}

	public void AddHealth ()
	{
		currentHealth += 20;
		UpdateScore ();
	}

	public void AddMoney()
	{
		score += 50;
		UpdateScore ();
	}

	public void SubHealth()
	{
		currentHealth -= 25;
		UpdateScore ();
	}
	public void GameOver()
	{
		gameOver = true;
		gameOverText.text = "GAME OVER!!";
	}

	public void GateFall()
	{
		restartText.text = "Go Save Your Friend!";
		gate.Fall ();
	}

	public void GameWin ()
	{
		gameOverText.text = "YOU WIN!!! CONGRATULATIONS!";
		Time.timeScale = 0f;
		restartText.text = "You Saved Your Friend!";
	}
}
