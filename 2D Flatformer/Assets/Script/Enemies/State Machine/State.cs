using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;

    public float startTime { get; private set; }
	protected string animBoolName;

	public State(FiniteStateMachine stateMachine, Entity entity, string animBoolName)
	{
		this.stateMachine = stateMachine;
		this.entity = entity;
		this.animBoolName = animBoolName;
	}

	public virtual void Enter()
	{
		startTime = Time.time;
		entity.anim.SetBool(animBoolName, true);
		DoCheck();
	}
	public virtual void Exit()
	{
		entity.anim.SetBool(animBoolName, false);

	}
	public virtual void LogicUpdate()
	{

	}
	public virtual void PhysicsUpdate()
	{
		DoCheck();
	}
	public virtual void DoCheck()
	{

	}
}
