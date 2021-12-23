using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Transform respawnPoint;
    [SerializeField]
    public Transform respawnPoint2;
    [SerializeField]
    public Transform respawnPoint3;
    [SerializeField]
    public Transform respawnPoint4;

    [SerializeField]
    public GameObject objQuest1;
    [SerializeField]
    public GameObject objQuest2;
    [SerializeField]
    public GameObject objQuest3;
    [SerializeField]
    public GameObject objQuest4;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;
    //[SerializeField]
    //private InventoryUI Canvas;

	//HealthBar healthBar;

	//[SerializeField]
	//private Camera playercamera;

    [SerializeField]
	private CinemachineVirtualCamera CVC;

	private void Awake()
	{
        objQuest1.SetActive(false);
        objQuest2.SetActive(false);
        objQuest3.SetActive(false);
        objQuest4.SetActive(false);
    }
	private void Start()
    {
        //CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        
        if(Player.instance.quest.title.Equals("Scout the enemy's lair 1"))
		{
            Player.instance.transform.position = respawnPoint.position;
            objQuest1.SetActive(true);
		}
        else if(Player.instance.quest.title.Equals("Scout the enemy's lair 2"))
		{
            Player.instance.transform.position = respawnPoint2.position;
            objQuest2.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies 3"))
        {
            Player.instance.transform.position = respawnPoint3.position;
            objQuest3.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Destroy all enemies 4"))
        {
            Player.instance.transform.position = respawnPoint4.position;
            objQuest4.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies s2 1"))
        {
            Player.instance.transform.position = respawnPoint.position;
            objQuest1.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies s2 2"))
        {
            Player.instance.transform.position = respawnPoint2.position;
            objQuest2.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Expanding the village 3"))
        {
            Player.instance.transform.position = respawnPoint3.position;
            objQuest3.SetActive(true);
        }
        else if (Player.instance.quest.title.Equals("Expanding the village 4"))
        {
            Player.instance.transform.position = respawnPoint4.position;
            objQuest4.SetActive(true);
        }
		else
		{
            Player.instance.transform.position = respawnPoint.position;
            objQuest1.SetActive(true);
            objQuest2.SetActive(true);
            objQuest3.SetActive(true);
            objQuest4.SetActive(true);
        }
        //Player.instance.transform.localScale = new Vector3(1f, 1f, 1f);
        //Player.instance.LoadDPlayer();
        CVC.m_Follow = Player.instance.transform;
        Player.instance.InputHandler.cam = Camera.main;
        CanvasMovenment.instance.gameObject.SetActive(true);
        
    }

    private void Update()
    {
        
        CheckRespawn();
    }
    public void Respawn()
    {
        respawnTimeStart = Time.time;
        respawn = true;
    }

    private void CheckRespawn()
    {
        if(Time.time >= respawnTimeStart + respawnTime && respawn)
        {
           
            var playerTemp = Instantiate(player, respawnPoint);
            //CVC.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }
}
