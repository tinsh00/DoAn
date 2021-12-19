using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VictoryCanvas : MonoBehaviour
{
    [SerializeField]
    Text textCompleteQuest;
    [SerializeField]
    Button btnRetry;
    [SerializeField]
    Button btnSave;
    
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.CompleteQuest();
        if (Player.instance.quest.goal.IsReacher())
		{
            textCompleteQuest.text = "Complete Quest";
            btnRetry.interactable = false;
            btnSave.interactable = true;
        }
        else
		{
            textCompleteQuest.color = Color.red;
            textCompleteQuest.text = "Fail Quest";
            btnRetry.interactable = true;
            btnSave.interactable = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadMenu()
    {
        Player.instance.GameOver.gameObject.SetActive(false);
        Player.instance.playerStatus.ResetHealth();
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
