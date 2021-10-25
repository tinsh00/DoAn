using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayerState : State
{
	protected D_LookForPlayerState stateData;

	protected bool turnImmediately;
	protected bool isPlayerInMinAgroRange;
	protected bool isAllTurnsDone;
	protected bool isAllTurnTimeDone;

	protected float lastTurnTime;

	protected float amountOfTurnDone;
	public LookForPlayerState(FiniteStateMachine stateMachine, Entity entity, string animBoolName, D_LookForPlayerState stateData) : base(stateMachine, entity, animBoolName)
	{
		this.stateData = stateData;
	}

	public override void DoCheck()
	{
		base.DoCheck();
		isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
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
		if (turnImmediately)
		{
			entity.Flip();
			lastTurnTime = Time.time;
			amountOfTurnDone++;
			turnImmediately = false;
		}
		else if(Time.time >= lastTurnTime +stateData.timeBetweenTurns && !isAllTurnsDone)
		{
			entity.Flip();
			lastTurnTime = Time.time;
			amountOfTurnDone++;
		}
		if (amountOfTurnDone >= stateData.amontOfTurn)
		{
			isAllTurnsDone = true;
		}

		if(Time.time >=lastTurnTime+stateData.timeBetweenTurns && isAllTurnsDone)
		{
			isAllTurnTimeDone = true;
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
	public void SetTurnImmediately(bool flip)
	{
		turnImmediately = flip;
	}
}
