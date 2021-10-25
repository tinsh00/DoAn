using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_IdleState : IdleState
{
	private Enemy1 enemy;
	public E1_IdleState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_IdleState stateData,Enemy1 enemy) : base(stateMachine, entity, animBoolName, stateData)
	{
		this.enemy = enemy;
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
		if (isIdleTimeOver)
		{
			stateMachine.ChangeState(enemy.moveState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
