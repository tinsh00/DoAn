using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
	protected D_MoveState stateData;
	protected bool isDetectedWall;
	protected bool isDetectedLedge;

	public MoveState(FiniteStateMachine stateMachine, Entity entity, string animBoolName,D_MoveState stateData) : base(stateMachine, entity, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void Enter()
	{
		base.Enter();
		entity.SetVelocity(stateData.movementSpeed);
		isDetectedLedge = entity.CheckLedge();
		isDetectedWall = entity.CheckWall();
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
		isDetectedLedge = entity.CheckLedge();
		isDetectedWall = entity.CheckWall();

	}
}
