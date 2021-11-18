using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5_ShieldState : ShieldState
{
	private Enemy5 enemy;

	public E5_ShieldState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, GameObject shield, GameObject Combat, D_ShieldState stateData, Enemy5 enemy) : base(etity, stateMachine, animBoolName, shield, Combat, stateData)
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
		enemy.CountHurt = 0;
		//core.Movement.SetVelocityX(0f);
	}

	public override void Exit()
	{
		
		base.Exit();
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (isShieldTimeOver)
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
