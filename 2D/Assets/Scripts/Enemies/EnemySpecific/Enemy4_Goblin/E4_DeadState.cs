using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_DeadState : DeadState
{
	private Enemy4_Goblin enemy;
	public E4_DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Enemy4_Goblin enemy) : base(etity, stateMachine, animBoolName, stateData)
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
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
