using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Player : Singleton<Player>
{
    
#region State Variables
public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallGrabState WallGrabState { get; private set; }
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerAttackState PrimaryAttackState { get; private set; }
    public PlayerAttackState SecondaryAttackState { get; private set; }
    public PlayerAttackState DefenseState { get; private set; }
    public PlayerAttackState KnifeAttackState { get; private set; }



    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public Core Core { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public Transform DashDirectionIndicator { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public PlayerInventory PlayerInventory { get; private set; }

    
    public PlayerStatus playerStatus;
    public Quest quest;
    public int questSuccess;
    public VictoryCanvas GameOver;
    
    
    #endregion

    #region Other Variables         

    private Vector2 workspace;
	#endregion

	#region Unity Callback Functions

	protected override void Awake()
	{
		base.Awake();
		Core = GetComponentInChildren<Core>();

		StateMachine = new PlayerStateMachine();

		IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
		MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
		JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
		InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
		LandState = new PlayerLandState(this, StateMachine, playerData, "land");
		WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
		WallGrabState = new PlayerWallGrabState(this, StateMachine, playerData, "wallGrab");
		WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
		WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "inAir");
		LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimbState");
		DashState = new PlayerDashState(this, StateMachine, playerData, "inAir");
		CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
		CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
		PrimaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
		SecondaryAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        DefenseState = new PlayerAttackState(this, StateMachine, playerData, "attack");
        KnifeAttackState = new PlayerAttackState(this, StateMachine, playerData, "attack");

        questSuccess = 0;
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        DashDirectionIndicator = transform.Find("DashDirectionIndicator");
        MovementCollider = GetComponent<BoxCollider2D>();
        PlayerInventory = GetComponent<PlayerInventory>();

        PrimaryAttackState.SetWeapon(PlayerInventory.weapons[(int)CombatInputs.primary]);
        SecondaryAttackState.SetWeapon(PlayerInventory.weapons[(int)CombatInputs.secondary]);
        DefenseState.SetWeapon(PlayerInventory.weapons[(int)CombatInputs.defense]);
        KnifeAttackState.SetWeapon(PlayerInventory.weapons[(int)CombatInputs.knife]);
        StateMachine.Initialize(IdleState);

		//if (DetailQuest.instance != null)
		//{
		//	Player.instance.quest.isActive = true;
		//	Player.instance.quest = DetailQuest.instance.quest;

		//}

	}

    private void Update()
    {
		//if (EventSystem.current.IsPointerOverGameObject())
		//{
		//	return;
		//}
		Core.LogicUpdate();
        StateMachine.CurrentState.LogicUpdate();

		if (Player.instance.playerStatus.currentHealth <= 0.0f)
		{
            Player.instance.GameOver.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions

    public void CompleteQuest()
	{
		if (quest.isActive)
		{
			if (quest.goal.IsReacher())
			{
                Player.instance.questSuccess++;
                Player.instance.playerStatus.IncreateCoin(quest.coinReward);
                Player.instance.playerStatus.IncreateExp(quest.expReward);

                SaveDPlayer();
            }
			else
			{
                LoadDPlayer();
			}
		}
		
	}
    public void DestroyPlayer()
	{
        Destroy(gameObject);
	}
    public void SaveDPlayer()
    {
        Debug.Log("save data");

        SaveSystem.SavePlayer();
    }
    public void LoadDPlayer()
    {
        DPlayer data = SaveSystem.LoadPlayer();
        if(data!=null)
		{
            Debug.Log("load data level :"+data.level);
            Player.instance.playerStatus.currentExp = data.currentExp;
            Player.instance.playerStatus.expSlider.SetExp(data.currentExp);
            Player.instance.playerStatus.level = data.level;
            Player.instance.playerStatus.LevelText.text = "LV." + Player.instance.playerStatus.level;
            //Player.instance.playerStatus.currentHealth = data.currentHealth;
            //Player.instance.playerStatus.healthBar.SetHealth(currentExp);
            Player.instance.playerStatus.coin = data.coin;
            Player.instance.playerStatus.coinText.text = "X" + Player.instance.playerStatus.coin;
            Player.instance.questSuccess = data.missionSuccess;
        }
       
        //Vector3 position;
        //position.x = data.position[0];
        //position.y = data.position[1];
        //position.z = data.position[2];

        //transform.parent.parent.position = position;
        //Debug.Log(position);
    }
    public void ResetPlayer()
    {
        Debug.Log("reset data");
        Player.instance.playerStatus.coin = 0;
        Player.instance.playerStatus.level = 0;
        Player.instance.playerStatus.currentExp = 0;
        SaveSystem.SavePlayer();
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        center.y += (height - MovementCollider.size.y) / 2;

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }   
   
    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

   
    #endregion
}
