using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteQuest : MonoBehaviour
{
    [SerializeField]
    VictoryCanvas questResultCanvas;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
            Debug.Log("ket thuc man choi");
            //SceneManager.LoadScene("Menu");
            questResultCanvas.gameObject.SetActive(true);

        }
	}
}
