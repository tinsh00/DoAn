using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
	protected D_MoveState stateData;
	protected bool isDetectedWall;
	protected bool isDetectedLedge;
	protected bool isPlayerInMinAgroRange;

	public MoveState(FiniteStateMachine stateMachine, Entity entity, string animBoolName,D_MoveState stateData) : base(stateMachine, entity, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void DoCheck()
	{
		base.DoCheck();
		isDetectedLedge = entity.CheckLedge();
		isDetectedWall = entity.CheckWall();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter()
	{
		base.Enter();
		entity.SetVelocity(stateData.movementSpeed);
		
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
