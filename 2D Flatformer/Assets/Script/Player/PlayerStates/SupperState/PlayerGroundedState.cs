using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
	protected int xInput;
	private bool JumpInput;
	private bool grabInput;
	private bool dashInput;
	private bool isGrounded;
	private bool isTouchingWall;
	private bool isTouchingLedge;
	
	public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{

	}

	public override void DoCheck()
	{
		base.DoCheck();
		isGrounded = player.CheckIfGrounded();
		isTouchingWall = player.CheckIfTouchingWall();
		isTouchingLedge = player.CheckIfTouchingLedge();
	}

	public override void Enter()
	{
		base.Enter();

		player.DashState.ResetCanDash();
		player.JumpState.ResetAmountOfJumpLeft();


	}

	public override void Exit()
	{

		base.Exit();
		
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		xInput = player.InputHandler.NormInputX;
		JumpInput = player.InputHandler.JumpInput;
		grabInput = player.InputHandler.GrabInput;
		dashInput = player.InputHandler.DashInput;
		if (JumpInput)
		{
			Debug.Log("kilavcl");
		}
		
		
		if (JumpInput && player.JumpState.CanJump())
		{
			stateMachine.ChangeState(player.JumpState);
		}
		else if (!isGrounded)
		{
			player.InAirState.StartCoyoteTime();
			stateMachine.ChangeState(player.InAirState);
		}
		else if(isTouchingWall && grabInput && isTouchingLedge)
		{
			stateMachine.ChangeState(player.WallGrabState);
		}
		else if (dashInput && player.DashState.CheckIfCanDash())
		{
			stateMachine.ChangeState(player.DashState);
		}
	}

	public override void PhysicUpdate()
	{
		base.PhysicUpdate();
	}
}
