using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_ChargeState : ChargeState
{
	private Enemy1 enemy;
	public E1_ChargeState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_ChargeState stateData, Enemy1 enemy) : base(stateMachine, entity, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void DoCheck()
	{
		base.DoCheck();
	}

	public override void Enter()
	{
		base.Enter();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();

		if(!isDetectedLedge || isDetectedWall)
		{
			stateMachine.ChangeState(enemy.lookForPlayerState);
		}
		else if (isChargeTimeOver)
		{
			if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
