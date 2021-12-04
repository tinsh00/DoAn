using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_PlayerDetected : PlayerDetectedState
{
	private Enemy4_Goblin enemy;
	public E4_PlayerDetected(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Enemy4_Goblin enemy) : base(etity, stateMachine, animBoolName, stateData)
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
			if (enemy.CountAttack >= 2)
				stateMachine.ChangeState(enemy.meleeSpecialAttackState);
			else
				stateMachine.ChangeState(enemy.meleeAttackState);
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
