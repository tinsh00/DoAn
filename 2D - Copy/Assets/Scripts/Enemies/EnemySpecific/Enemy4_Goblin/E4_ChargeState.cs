using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_ChargeState : ChargeState
{
	private Enemy4_Goblin enemy;
	public E4_ChargeState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Enemy4_Goblin enemy) : base(etity, stateMachine, animBoolName, stateData)
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
				stateMachine.ChangeState(enemy.meleeAttackState);
			else
				stateMachine.ChangeState(enemy.meleeSpecialAttackState);
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
