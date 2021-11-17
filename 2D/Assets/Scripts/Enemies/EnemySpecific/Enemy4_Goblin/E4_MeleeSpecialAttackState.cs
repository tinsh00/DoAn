using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_MeleeSpecialAttackState : MeleeAttackState
{
	private Enemy4_Goblin enemy;
	public E4_MeleeSpecialAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Enemy4_Goblin enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
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
		enemy.count = 0;
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void FinishAttack()
	{
		base.FinishAttack();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (isAnimationFinished)
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

	public override void TriggerAttack()
	{
		base.TriggerAttack();
	}
}
