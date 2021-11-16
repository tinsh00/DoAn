using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3_Wizard : Entity
{
	public E3_MoveState moveState { get; private set; }
	public E3_IdleState idleState { get; private set; }
	public E3_PlayerDetectedState playerDetectedState { get; private set; }
	public E3_MeleeAttackState meleeAttackState { get; private set; }
	public E3_LookForPlayerState lookForPlayerState { get; private set; }




	[SerializeField]
	private D_MoveState moveStateData;
	[SerializeField]
	private D_IdleState idleStateData;
	[SerializeField]
	private D_PlayerDetected playerDetectedData;
	[SerializeField]
	private D_MeleeAttack meleeAttackData;
	[SerializeField]
	private D_LookForPlayer lookForPlayerData;


	[SerializeField]
	private Transform meleeAttackPosition;



	public override void Awake()
	{
		base.Awake();

		moveState = new E3_MoveState(this, stateMachine, "move", moveStateData, this);
		idleState = new E3_IdleState(this, stateMachine, "idle", idleStateData, this);
		playerDetectedState = new E3_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
		meleeAttackState = new E3_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackData, this);
		lookForPlayerState = new E3_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);

	}
	private void Start()
	{
		stateMachine.Initialize(moveState);
	}
	public override void Update()
	{
		base.Update();

	}
	public override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackData.attackRadius);
	}

}
