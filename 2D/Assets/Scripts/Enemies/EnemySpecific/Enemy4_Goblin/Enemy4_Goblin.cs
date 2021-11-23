using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4_Goblin : Entity
{
	public E4_MoveState moveState { get; private set; }
	public E4_IdleState idleState { get; private set; }
	public E4_PlayerDetected playerDetectedState { get; private set; }
	public E4_LookForPlayer lookForPlayerState { get; private set; }
	public E4_ChargeState chargeState { get; private set; }
	public E4_MeleeAttackState meleeAttackState { get; private set; }
	public E4_DeadState deadState { get; private set; }
	public E4_MeleeSpecialAttackState meleeSpecialAttackState { get; private set; }
	public E4_HurtState hurtState { get; private set; }



	[SerializeField]
	private D_MoveState MoveStateData;
	[SerializeField]
	private D_IdleState IdleStateData;
	[SerializeField]
	private D_PlayerDetected PlayerDetectedData;
	[SerializeField]
	private D_LookForPlayer lookForPlayerData;
	[SerializeField]
	private D_ChargeState chargeStateData;
	[SerializeField]
	private D_MeleeAttack meleeAttackData;
	[SerializeField]
	private D_DeadState deadStateData;
	[SerializeField]
	private D_MeleeAttack meleeSpecialAttackData;
	[SerializeField]
	private D_HurtState hurtStateData;


	[SerializeField]
	private Transform meleeAttackPosition;
	[SerializeField]
	private Transform meleeSpecialAttackPosition;


	[SerializeField]
	private string deadVoice = "deadEnemy";
	[SerializeField]
	private string hurtVoice = "hurtEnemy";
	[SerializeField]
	public Stats stats;
	public int CountAttack;

	public override void Awake()
	{
		base.Awake();
		CountAttack = 0;
		moveState = new E4_MoveState(this, stateMachine, "move", MoveStateData, this);
		idleState = new E4_IdleState(this, stateMachine, "idle", IdleStateData, this);
		playerDetectedState = new E4_PlayerDetected(this, stateMachine, "playerDetected", PlayerDetectedData, this);
		lookForPlayerState = new E4_LookForPlayer(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
		chargeState = new E4_ChargeState(this, stateMachine, "charge", chargeStateData, this);
		meleeAttackState = new E4_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackData, this);
		deadState = new E4_DeadState(this, stateMachine, "dead", deadStateData, this);
		meleeSpecialAttackState = new E4_MeleeSpecialAttackState(this, stateMachine, "meleeSpecialAttack", meleeSpecialAttackPosition, meleeSpecialAttackData, this);
		hurtState = new E4_HurtState(this, stateMachine, "hurt", hurtStateData, this);
	}

	private void Start()
	{
		stateMachine.Initialize(moveState);
	}

	public override void FixedUpdate()
	{
		base.FixedUpdate();
	}
	public override void Update()
	{
		base.Update();
		
		if (stats.currentHealth <= 0.0f)
		{
			stateMachine.ChangeState(deadState);
			AudioManager.instance.PlaySound(deadVoice);
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
		Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
		Gizmos.DrawWireSphere(meleeSpecialAttackPosition.position, meleeSpecialAttackData.attackRadius);
	}


	private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

	private void AnimtionFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
