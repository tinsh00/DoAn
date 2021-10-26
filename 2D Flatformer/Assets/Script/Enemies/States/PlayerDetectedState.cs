using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectedState : State
{
	protected D_PlayerDetectedState stateData;

	protected bool isPlayerInMinAgroRange;
	protected bool isPlayerInMaxAgroRange;
	protected bool performLongRangeAction;
	protected bool performShortRangeAction;
	protected bool performCloseRangeAction;
	protected bool isDetectedLedge;
	public PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetectedState stateData) : base(stateMachine, entity, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void DoCheck()
	{
		base.DoCheck();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
		isPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
		isDetectedLedge = entity.CheckLedge();

		performShortRangeAction = entity.CheckPlayerInCloseRangeAction();
		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
	}

	public override void Enter()
	{
		base.Enter();

		entity.SetVelocity(0f);

		



	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if (Time.time >= startTime + stateData.longRangeActionTime)
		{
			performLongRangeAction = true;
		}

	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
