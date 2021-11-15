using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{
	protected SO_AggressiveWeaponData aggressiveWeaponData;

	public float TimeToHold;

	public override void AnimationActionTrigger()
	{
		base.AnimationActionTrigger();
	}

	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

	public override void AnimationStartMovementTrigger()
	{
		base.AnimationStartMovementTrigger();
	}

	public override void AnimationStopMovementTrigger()
	{
		base.AnimationStopMovementTrigger();
	}

	public override void AnimationTurnOffFlipTrigger()
	{
		base.AnimationTurnOffFlipTrigger();
	}

	public override void AnimationTurnOnFlipTigger()
	{
		base.AnimationTurnOnFlipTigger();
	}

	public override void EnterWeapon()
	{
		base.EnterWeapon();
		Debug.Log("shield");
		baseAnimator.SetBool("enter", true);
		weaponAnimator.SetBool("enter", true);
		
	}
	private void Update()
	{
		
		if (Time.time >= TimerStartHolder + TimerHolder)
		{
			baseAnimator.SetBool("enter", false);
			weaponAnimator.SetBool("enter", false);

			baseAnimator.SetBool("hold", true);
			weaponAnimator.SetBool("hold", true);
		}
	}
	public override void ExitWeapon()
	{
		base.ExitWeapon();

		baseAnimator.SetBool("exit", true);
		weaponAnimator.SetBool("exit", true);
	}

	protected override void Awake()
	{
		base.Awake();
		if (weaponData.GetType() == typeof(SO_AggressiveWeaponData))
		{
			aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
		}
		else
		{
			Debug.LogError("Wrong data for the weapon");
		}
	}
}
