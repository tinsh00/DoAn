using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	public void QuitGame()
	{
		Time.timeScale = 1f;
		//Player.instance.playerStatus.ResetHealth();
		Debug.Log("Application quit");
		Application.Quit();
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		//Player.instance.playerStatus.ResetHealth();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void LoadMenu()
	{
		Time.timeScale = 1f;
		//Player.instance.playerStatus.ResetHealth();
		SceneManager.LoadScene("Menu");
	}
}
