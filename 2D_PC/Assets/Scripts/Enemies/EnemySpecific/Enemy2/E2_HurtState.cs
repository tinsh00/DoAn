using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2_HurtState : HurtState
{
	private Enemy2 enemy;
	public E2_HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HurtState stateData, Enemy2 enemy) : base(etity, stateMachine, animBoolName, stateData)
	{
		this.enemy = enemy;
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

	public override void AnimationTrigger()
	{
		base.AnimationTrigger();
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
		enemy.stats.hurt = false;
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
}
