using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4_MoveState : MoveState
{
	private Enemy4_Goblin enemy;
	public E4_MoveState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Enemy4_Goblin enemy) : base(etity, stateMachine, animBoolName, stateData)
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
		if (isPlayerInMinAgroRange)
		{
			stateMachine.ChangeState(enemy.playerDetectedState);
		}
		else if (isDetectingWall || !isDetectingLedge)
		{
			enemy.idleState.SetFlipAfterIdle(true);
			stateMachine.ChangeState(enemy.idleState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
