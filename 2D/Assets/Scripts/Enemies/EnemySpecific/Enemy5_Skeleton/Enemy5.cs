using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5 : Entity
{
	public E5_MoveState moveState { get; private set; }
	public E5_IdleState idleState { get; private set; }
	public E5_PlayerDetectedState playerDetectedState { get; private set; }
	public E5_ChargeState chargeState { get; private set; }
	public E5_LookForPlayerState lookForPlayerState { get; private set; }
	public E5_MeleeAttack1State meleeAttack1State { get; private set; }
	public E5_MeleeAttack2State meleeAttack2State { get; private set; }
	public E5_HurtState hurtState { get; private set; }
	public E5_DeadState deadState { get; private set; }
	public E5_ShieldState shieldState { get; private set; }




	[SerializeField]
	private D_MoveState moveStateData;
	[SerializeField]
	private D_IdleState idleStateData;
	[SerializeField]
	private D_PlayerDetected playerDetectedStateData;
	[SerializeField]
	private D_ChargeState chargeStateData;
	[SerializeField]
	private D_LookForPlayer lookForPlayerData;
	[SerializeField]
	private D_MeleeAttack meleeAttack1Data;
	[SerializeField]
	private D_MeleeAttack meleeAttack2Data;
	[SerializeField]
	private D_HurtState hurtStateData;
	[SerializeField]
	private D_DeadState deadStateData;
	[SerializeField]
	private D_ShieldState shieldStateData;


	[SerializeField]
	private Transform meleeAttack1Position;
	[SerializeField]
	private Transform meleeAttack2Position;

	[SerializeField]
	private GameObject shieldGO;
	[SerializeField]
	private GameObject CombatGO;

	[SerializeField]
	private string deadVoice = "deadEnemy";
	[SerializeField]
	private string hurtVoice = "hurtEnemy";

	public Stats stats;
	public int CountAttack;
	public int CountHurt;



	public override void Awake()
	{
		base.Awake();
		CountAttack = 0;
		CountHurt = 0;
		moveState = new E5_MoveState(this, stateMachine, "move", moveStateData, this);
		idleState = new E5_IdleState(this, stateMachine, "idle", idleStateData, this);
		playerDetectedState = new E5_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
		chargeState = new E5_ChargeState(this, stateMachine, "charge", chargeStateData, this);
		lookForPlayerState = new E5_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
		meleeAttack1State = new E5_MeleeAttack1State(this, stateMachine, "attack1", meleeAttack1Position, meleeAttack1Data, this);
		meleeAttack2State = new E5_MeleeAttack2State(this, stateMachine, "attack2", meleeAttack2Position, meleeAttack2Data, this);
		hurtState = new E5_HurtState(this, stateMachine, "hurt", hurtStateData, this);
		deadState = new E5_DeadState(this, stateMachine, "dead", deadStateData, this);
		shieldState = new E5_ShieldState(this, stateMachine, "shield", shieldGO,CombatGO, shieldStateData, this) ;
	}
	private void Start()
	{
		stateMachine.Initialize(moveState);
	}
	public override void Update()
	{
		base.Update();
		if (stats.currentHealth <= 0.0f)
		{
			stateMachine.ChangeState(deadState);
			AudioManager.instance.PlaySound(deadVoice);

		}
		else if (CountHurt >= 2) 
		{
			stateMachine.ChangeState(shieldState);
			shieldGO.SetActive(true);
			
		}
		else if (stats.hurt)
		{
			stateMachine.ChangeState(hurtState);
			AudioManager.instance.PlaySound(hurtVoice);

		}
	}

	public override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		Gizmos.DrawWireSphere(meleeAttack1Position.position, meleeAttack1Data.attackRadius);
		Gizmos.DrawWireSphere(meleeAttack2Position.position, meleeAttack2Data.attackRadius);
	}
	private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

	private void AnimtionFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
