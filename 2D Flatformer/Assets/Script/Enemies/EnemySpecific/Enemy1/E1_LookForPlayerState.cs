using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LookForPlayerState : LookForPlayerState
{
	private Enemy1 enemy;
	public E1_LookForPlayerState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_LookForPlayerState stateData, Enemy1 enemy) : base(stateMachine, entity, animBoolName, stateData)
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
		isAllTurnsDone = false;
		isAllTurnTimeDone = false;

		lastTurnTime = startTime;
		amountOfTurnDone = 0;

		entity.SetVelocity(0f);
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
		else if (isAllTurnTimeDone)
		{
			stateMachine.ChangeState(enemy.moveState);
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
