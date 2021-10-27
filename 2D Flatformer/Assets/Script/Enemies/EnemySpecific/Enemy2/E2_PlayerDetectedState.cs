using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_PlayerDetectedState : PlayerDetectedState
{
	private Enemy2 enemy;
	public E2_PlayerDetectedState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_PlayerDetectedState stateData, Enemy2 enemy) : base(stateMachine, entity, animBoolName, stateData)
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

		if (performCloseRangeAction)
		{
			if(Time.time >= enemy.dodgeState.startTime + enemy.dodgeStateData.dodgeCooldown)
			{
				stateMachine.ChangeState(enemy.dodgeState);
			}
			else
			{
				stateMachine.ChangeState(enemy.meleeAttackState);
			}
		}
		else if (performLongRangeAction)
		{
			stateMachine.ChangeState(enemy.rangeAttackState);
		}
		else if (!isPlayerInMaxAgroRange)
		{
			stateMachine.ChangeState(enemy.lookForPlayerState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
