using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListQuestManage : MonoBehaviour
{
    
    public Button[] listQ;
    public static int i;
    
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < listQ.Length; i++)
		{
			if (i <= Player.instance.questSuccess)
			{
               listQ[i].interactable=true;
			}
            else
			{
                listQ[i].interactable = false;
                //listQ[i].onClick.AddListener(() => OnUIButtonClick(i));
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
		
	}

 //   public void OnUIButtonClick(int i)
	//{
 //       textNoti.text = "Please Complete Quest " + Player.instance.questSuccess+1 +" fỉrst!!!";
 //   }
    
}
