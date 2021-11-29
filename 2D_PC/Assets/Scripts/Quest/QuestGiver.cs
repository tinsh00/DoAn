using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
	public Quest quest;
	//public Player player;

	

	public string sceneText;
	public void OpenQuestWindow()
	{
		DetailQuest.instance.questGiver = this;
		DetailQuest.instance.gameObject.SetActive(true);
		DetailQuest.instance.SetDetailQuest();
		

	}


}
