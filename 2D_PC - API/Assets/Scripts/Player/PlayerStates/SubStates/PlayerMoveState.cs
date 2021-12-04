using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private string movePlayer = "movePlayer";
    private IEnumerator playerRun;
    //private bool isStartCo;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }
    
    public override void Enter()
    {
        base.Enter();
        //isStartCo = true;
        //playerRun = AudioRun();
        player.StartCoroutine(AudioRun());

    }

    public override void Exit()
    {
        base.Exit();
        player.StopAllCoroutines();
    }

    public override void LogicUpdate()
    {
		base.LogicUpdate();
        
        core.Movement.CheckIfShouldFlip(xInput);

        core.Movement.SetVelocityX(playerData.movementVelocity * xInput);
        //AudioManager.instance.PlaySound(movePlayer);

        if (!isExitingState)
        {
            
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchMoveState);
            }
        }        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }
    private IEnumerator AudioRun()
	{
        //Debug.Log("start run");
        
        while (true)
		{
            
            yield return new WaitForSeconds(.25f);
            //Debug.Log("run");
            
                AudioManager.instance.PlaySound(movePlayer);
        }

	}
}
