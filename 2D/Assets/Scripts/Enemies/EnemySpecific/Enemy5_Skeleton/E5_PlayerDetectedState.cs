using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_PlayerDetectedState : PlayerDetectedState
{
	private Enemy5 enemy;
	public E5_PlayerDetectedState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, stateData)
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
			if (enemy.CountAttack < 2)
				stateMachine.ChangeState(enemy.meleeAttack1State);
			else
				stateMachine.ChangeState(enemy.meleeAttack2State);
		}
		else if (performLongRangeAction)
		{
			stateMachine.ChangeState(enemy.chargeState);
		}
		else if (!isPlayerInMaxAgroRange)
		{
			stateMachine.ChangeState(enemy.lookForPlayerState);
		}
		else if (!isDetectingLedge)
		{
			core.Movement.Flip();
			stateMachine.ChangeState(enemy.moveState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
