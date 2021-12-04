using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : Weapon
{
	protected SO_AggressiveWeaponData aggressiveWeaponData;

	protected GameObject projectile ;
	protected Projectile projectileScript;
	public GameObject projectileaction;
	public float projectileDamage = 10f;
	public float projectileSpeed = 12f;
	public float projectileTravelDistance = 12f;
	public Transform attackPosition;
	float[] distanceY  ;
	public override void AnimationActionTrigger()
	{
		base.AnimationActionTrigger();
		if (attackCounter == 2)
		{
			distanceY = new float[3];
			distanceY[0] = attackPosition.position.y - .4f;
			distanceY[1] = attackPosition.position.y;
			distanceY[2] = attackPosition.position.y + .4f;

			for (int i = 0; i < aggressiveWeaponData.amountOfWeapons.Length; i++)
			{
				
				projectile = GameObject.Instantiate(projectileaction, new Vector3(attackPosition.position.x, distanceY[i], attackPosition.position.z), attackPosition.rotation);
				projectileScript = projectile.GetComponent<Projectile>();
				projectileScript.FireProjectile(projectileSpeed, projectileTravelDistance, projectileDamage);
			}
		}
		else
		{

			projectile = GameObject.Instantiate(projectileaction, attackPosition.position, attackPosition.rotation);
			projectileScript = projectile.GetComponent<Projectile>();
			projectileScript.FireProjectile(projectileSpeed, projectileTravelDistance, projectileDamage);

		}



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
	}

	public override void ExitWeapon()
	{
		base.ExitWeapon();
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
