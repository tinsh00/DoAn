using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
	public Quest quest;
	//public Player player;
	public GameObject DQuest;
	

	public string sceneText;
	public void OpenQuestWindow()
	{
		DetailQuest.instance.questGiver = this;
		DQuest.SetActive(true);
		DetailQuest.instance.SetDetailQuest();
		

	}

	
}
