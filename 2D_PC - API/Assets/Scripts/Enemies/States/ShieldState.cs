using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldState : State
{
	private D_ShieldState stateData;

	protected GameObject shield;
	protected GameObject combat;

	protected bool isShieldTimeOver;
	protected bool performCloseRangeAction;
	protected bool isPlayerInMinAgroRange;
	
	public ShieldState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, GameObject shield,GameObject Combat, D_ShieldState stateData) : base(etity, stateMachine, animBoolName)
	{
		this.combat = Combat;
		this.shield = shield;
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
		isShieldTimeOver = false;
		core.Movement.SetVelocityX(0f);
		
		shield.SetActive(true);
		combat.SetActive(false);
		

	}

	public override void Exit()
	{
		base.Exit();
		entity.ResetShieldResistance();
		shield.SetActive(false); 
		combat.SetActive(true);
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		
		if (Time.time >= startTime + stateData.ShieldTime)
		{
			isShieldTimeOver = true;
		}

	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
