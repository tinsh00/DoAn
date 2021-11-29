using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;

	public GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!GameIsPause)
			{
				Pause();
			}
			else
				Resume();
		}
		
    }

	public void Pause()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
		GameIsPause = true;
	}

	public void Resume()
	{
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
		GameIsPause = false;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{
		Debug.Log("Quit game");
		Application.Quit();
	}
}
