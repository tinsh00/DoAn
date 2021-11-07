using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{

	public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
	}

	public override void DoCheck()
	{
		base.DoCheck();

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


		if (xInput != 0f && !isExitingState)
		{
			stateMachine.ChangeState(player.MoveState);
		}
	}

	public override void PhysicUpdate()
	{
		base.PhysicUpdate();
	}

}
