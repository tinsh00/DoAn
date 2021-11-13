using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetailQuest : Singleton<DetailQuest>
{
    public QuestGiver questGiver;
	public Quest quest;

	public Text titleText;
	public Text descriptionText;
	public Text expText;
	public Text coinText;
	int i;

	
	protected override void Awake()
	{
		base.Awake();
		i++;
		Debug.Log(i++);
	}

	public void SetDetailQuest()
	{
		quest = questGiver.quest;
		titleText.text = quest.title;
		descriptionText.text = quest.description;
		expText.text = quest.expReward.ToString();
		coinText.text = quest.coinReward.ToString();
	}
	public void ResetDetailQuest()
	{
		
		titleText.text = "";
		descriptionText.text = "";
		expText.text = "0";
		coinText.text = "0";
	}
	public void SetActive(bool flag)
	{
		questGiver.DQuest.SetActive(flag);
	}

	public void AttackQuest()
	{
		questGiver.DQuest.SetActive(false);
		quest.isActive = true;


		SceneManager.LoadScene(questGiver.sceneText);
		

	}
}
