using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
	private Vector2 detectedPos;
	private Vector2 cornerPos;
	private Vector2 startPos;
	private Vector2 stopPos;

	private bool isHanding;
	private bool isClimbing;
	private bool jumpInput;

	private int xInput;
	private int yInput;
	public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
	{
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
		player.Anim.SetBool("climbLedge", false);
	}

	public override void AnimationTrigger()
	{
		base.AnimationTrigger();

		isHanding = true;
	}

	public override void Enter()
	{
		base.Enter();
		player.SetVelocityZero();
		player.transform.position = detectedPos;
		cornerPos = player.DetermineCornerPosition();

		startPos.Set(cornerPos.x - (player.FacingDirection * playerData.startOffset.x), cornerPos.y - playerData.startOffset.y);
		stopPos.Set(cornerPos.x + (player.FacingDirection * playerData.stopOffset.x), cornerPos.y + playerData.stopOffset.y);

		player.transform.position = startPos;

	}

	public override void Exit()
	{
		base.Exit();

		isHanding = false;

		if (isClimbing)
		{
			player.transform.position = stopPos;
			isClimbing = false;
		}
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
		xInput = player.InputHandler.NormInputX;
		yInput = player.InputHandler.NormInputY;
		jumpInput = player.InputHandler.JumpInput;
		if (jumpInput)
		{
			Debug.Log("jump");
		}

		if (isAnimationFinished)
		{
			stateMachine.ChangeState(player.IdleState);
		}
		else
		{

			player.SetVelocityZero();
			player.transform.position = startPos;

			if (xInput == player.FacingDirection && isHanding && !isClimbing)
			{
				isClimbing = true;
				player.Anim.SetBool("climbLedge", true);
			}
			else if (yInput == -1 && isHanding && !isClimbing)
			{
				stateMachine.ChangeState(player.InAirState);
			}
			else if(jumpInput && !isClimbing)
			{
				player.WallJumpState.DetermineWallJumpDirection(true);
				stateMachine.ChangeState(player.WallJumpState);
			}
		}

	}

	public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;


}
