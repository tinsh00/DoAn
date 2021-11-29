using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : State
{
	private D_HurtState stateData;


	protected bool performCloseRangeAction;
	protected bool isPlayerInMinAgroRange;
	public HurtState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_HurtState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.stateData = stateData;
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

		performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
	}

	public override void Enter()
	{
		base.Enter();

		isAnimationFinished = false;
		core.Movement.SetVelocityZero();
	}

	public override void Exit()
	{
		base.Exit();

	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		if (isAnimationFinished)
		{
			Exit();
		}

		
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
	
}
