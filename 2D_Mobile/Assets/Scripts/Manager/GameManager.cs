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
    private GameObject player;
    [SerializeField]
    private float respawnTime;

    private float respawnTimeStart;

    private bool respawn;
    //[SerializeField]
    //private InventoryUI Canvas;

    //HealthBar healthBar;

    private CinemachineVirtualCamera CVC;

	private void Awake()
	{
        Player.instance.transform.position = respawnPoint.position;
    }
	private void Start()
    {
        CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        CVC.m_Follow = Player.instance.transform;
        if (Player.instance.quest.title.Equals("Scout the enemy's lair 1"))
        {
            Player.instance.transform.position = respawnPoint.position;
        }
        else if (Player.instance.quest.title.Equals("Scout the enemy's lair 2"))
        {
            Player.instance.transform.position = respawnPoint2.position;
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies 3"))
        {
            Player.instance.transform.position = respawnPoint3.position;
        }
        else if (Player.instance.quest.title.Equals("Destroy all enemies 4"))
        {
            Player.instance.transform.position = respawnPoint4.position;
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies s2 1"))
        {
            Player.instance.transform.position = respawnPoint.position;
        }
        else if (Player.instance.quest.title.Equals("Hunt down the enemies s2 2"))
        {
            Player.instance.transform.position = respawnPoint2.position;
        }
        else if (Player.instance.quest.title.Equals("Expanding the village 3"))
        {
            Player.instance.transform.position = respawnPoint3.position;
        }
        else if (Player.instance.quest.title.Equals("Expanding the village 4"))
        {
            Player.instance.transform.position = respawnPoint4.position;
        }
        else
        {
            Player.instance.transform.position = respawnPoint.position;
        }
        //Player.instance.transform.localScale = new Vector3(1f, 1f, 1f);
        Player.instance.LoadDPlayer();
        //Canvas.gameObject.SetActive(true);
        // Debug.Log(Canvas.gameObject.name);
        //Player.instance.GameOver.gameObject.SetActive(true);
        //Debug.Log(Player.instance.GameOver.transform.parent.gameObject);
        CanvasMovement.instance.gameObject.SetActive(true);

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
            CVC.m_Follow = playerTemp.transform;
            respawn = false;
        }
    }
}
