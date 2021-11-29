using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_ChargeState : ChargeState
{
	private Enemy5 enemy;
	public E5_ChargeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void DoChecks()
	{
		base.DoChecks();
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
		if (performCloseRangeAction)
		{
			if(enemy.CountAttack < 2)
				stateMachine.ChangeState(enemy.meleeAttack1State);
			else
				stateMachine.ChangeState(enemy.meleeAttack2State);
		}
		else if (!isDetectingLedge || isDetectingWall)
		{
			stateMachine.ChangeState(enemy.lookForPlayerState);
		}
		else if (isChargeTimeOver)
		{
			if (isPlayerInMinAgroRange)
			{
				stateMachine.ChangeState(enemy.playerDetectedState);
			}
			else
			{
				stateMachine.ChangeState(enemy.lookForPlayerState);
			}
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
