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
			if (GameIsPause)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	private void Pause()
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
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame()
	{
		Debug.Log("Quit game");
		Application.Quit();
	}
}
