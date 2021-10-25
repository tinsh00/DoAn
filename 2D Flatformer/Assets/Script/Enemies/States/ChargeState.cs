using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
	protected D_ChargeState stateData;

	protected bool isPlayerInMinAgroRange;
	protected bool isDetectedLedge;
	protected bool isDetectedWall;
	protected bool isChargeTimeOver;
	public ChargeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData) : base(stateMachine, entity, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void DoCheck()
	{
		base.DoCheck();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		isDetectedLedge = entity.CheckLedge();
		isDetectedWall = entity.CheckWall();
	}

	public override void Enter()
	{
		base.Enter();
		isChargeTimeOver = false;
		entity.SetVelocity(stateData.chargeSpeed);
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (Time.time >= startTime + stateData.chargeTime)
		{
			isChargeTimeOver = true;
		}

	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
