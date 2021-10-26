using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
	protected Transform attackPosition;
	protected bool isAnimationFinished;
	protected bool isPlayerInMinAgroRange;
	public AttackState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, Transform attackPosition) : base(stateMachine, entity, animBoolName)
	{
		this.attackPosition = attackPosition;
	}

	public override void DoCheck()
	{
		base.DoCheck();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter()
	{
		base.Enter();

		entity.atsm.attackState = this;
		isAnimationFinished = false;
		entity.SetVelocity(0f);
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
	public virtual void TriggerAttack()
	{

	}
	public virtual void FinishActack()
	{
		isAnimationFinished = true;
	}
}
