using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	//AudioManager audioManager;
	[SerializeField]
	string hoverOverSound = "ButtonHover";

	[SerializeField]
	string pressButtonSound = "ButtonPress";
	private void Start()
	{
		//Player.instance.SaveDPlayer();
		Player.instance.LoadDPlayer();
	}
	public void PlayGame()
	{
		
	}

	public void QuitGame()
	{
		
		Debug.Log("Quit game");
		Application.Quit();
	}
	public void OnMouseOver()
	{
		AudioManager.instance.PlaySound(hoverOverSound);
	}
	public void OnMouseDown()
	{
		AudioManager.instance.PlaySound(pressButtonSound);
	}

}
