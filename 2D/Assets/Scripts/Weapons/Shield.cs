using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Weapon
{
	protected SO_AggressiveWeaponData aggressiveWeaponData;

	[SerializeField]
	private LayerMask whatIsProje;
	[SerializeField]
	private Transform shieldPosition;
	[SerializeField]
	private float shieldRadius;


	private bool isFinishAnimationParry;
	private bool isShieldHit;
	Collider2D shieldHit;

	public bool isFinishEnter;

	private void Start()
	{

	}
	

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

	public  void AnimationFinishEnterState()
	{
		isFinishEnter = true;
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
		if (state.shieldInput)
		{
			if (isFinishEnter)
			{
				//Debug.Log("hold shield");
				Player.instance.Core.Combat.gameObject.SetActive(false);
				baseAnimator.SetBool("hold", true);
				weaponAnimator.SetBool("hold", true);

				baseAnimator.SetBool("enter", false);
				weaponAnimator.SetBool("enter", false);

				if (isShieldHit || CheckShieldHit())
				{
					StartParry();
				}
				else if (isFinishAnimationParry)
				{
					FinishParry();
				}
			}			
		}
		else if(!state.shieldInput)
		{
			baseAnimator.SetBool("enter", false);
			weaponAnimator.SetBool("enter", false);

			baseAnimator.SetBool("hold", false);
			weaponAnimator.SetBool("hold", false);

			baseAnimator.SetBool("exit", true);
			weaponAnimator.SetBool("exit", true);
		}
	}
	public override void ExitWeapon()
	{
		base.ExitWeapon();

		baseAnimator.SetBool("exit", true);
		weaponAnimator.SetBool("exit", true);
		Player.instance.Core.Combat.gameObject.SetActive(true);
		SetShieldHitMeleeAttack(false);
		isFinishEnter = false;


	}
	public bool CheckShieldHit()
	{
		return shieldHit = Physics2D.OverlapCircle(shieldPosition.position, shieldRadius, whatIsProje);

	}
	public void SetShieldHitMeleeAttack(bool shieldhit)
	{
		isShieldHit = shieldhit;
	}
	public void StartParry()
	{
		//Debug.Log("Shield hit");
		weaponAnimator.SetBool("hold", false);
		weaponAnimator.SetBool("parry", true);
		if (shieldHit)
			Destroy(shieldHit.gameObject);
	}
	public void FinishParry()
	{
		weaponAnimator.SetBool("parry", false);
		weaponAnimator.SetBool("hold", true);
		isFinishAnimationParry = false;

	}
	public void FinishAnimationParry()
	{
		isFinishAnimationParry = true;
		isShieldHit = false;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(shieldPosition.position, shieldRadius);
	}

	protected override void Awake()
	{
		base.Awake();
		isFinishAnimationParry = false;
		isShieldHit = false;
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
