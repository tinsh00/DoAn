using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;

    private int xInput;

    private float velocityToSet;

    private bool setVelocity;
    private bool shouldCheckFlip;

    public bool shieldInput;
    public float shieldInputStart;
    public bool shieldInputStop;

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        setVelocity = false;

        weapon.EnterWeapon();
        shieldInputStart = player.GetComponent<PlayerInputHandler>().shieldInputStartTime;
    }

    public override void Exit()
    {
        base.Exit();

        weapon.ExitWeapon();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.InputHandler.NormInputX;
        shieldInput = player.InputHandler.ShieldInput;
        shieldInputStop = player.InputHandler.ShieldInputStop;
        shieldInputStart = player.InputHandler.shieldInputStartTime;

        if (shouldCheckFlip)
        {
            core.Movement.CheckIfShouldFlip(xInput);
        }


        if (setVelocity)
        {
            core.Movement.SetVelocityX(velocityToSet * core.Movement.FacingDirection);
        }
		//if (shieldInput && Time.time)
		//	if (!shieldInput)
		//	{
				

		//	}
	}

    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
        this.weapon.InitializeWeapon(this, core);
    }

    public void SetPlayerVelocity(float velocity)
    {
        core.Movement.SetVelocityX(velocity * core.Movement.FacingDirection);

        velocityToSet = velocity;
        setVelocity = true;
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    #region Animation Triggers

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();                

        isAbilityDone = true;
    }

    #endregion
}
