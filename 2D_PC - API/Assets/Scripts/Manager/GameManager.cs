using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Transform respawnPoint;
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
        
    }
	private void Start()
    {
        //CVC = GameObject.Find("Player Camera").GetComponent<CinemachineVirtualCamera>();
        CVC.m_Follow = Player.instance.transform;
        Player.instance.transform.position = respawnPoint.position;
        //Player.instance.transform.localScale = new Vector3(1f, 1f, 1f);
        //Player.instance.LoadDPlayer();
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
