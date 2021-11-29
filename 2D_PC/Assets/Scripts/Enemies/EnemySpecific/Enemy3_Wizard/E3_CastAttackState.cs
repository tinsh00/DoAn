using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3_CastAttackState : RangedAttackState
{
	private Enemy3_Wizard enemy;
	string cast = "cast";
	public E3_CastAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_RangedAttackState stateData, Enemy3_Wizard enemy) : base(etity, stateMachine, animBoolName, attackPosition, stateData)
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
		AudioManager.instance.PlaySound(cast);
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
		projectile = GameObject.Instantiate(stateData.projectile, new Vector3(Player.instance.transform.position.x, Player.instance.transform.position.y + 2f, Player.instance.transform.position.z), Player.instance.transform.rotation) ;
	}
}
