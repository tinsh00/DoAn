using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [SerializeField]
    private bool combatEnable;
	[SerializeField]
	private float inputTimer, attack1Radius, attack1Dame;
	[SerializeField]
	private Transform attack1HitBoxPos;
	[SerializeField]
	private LayerMask whatIsDamageble;
	private bool gotInput, isAttacking, isFirstAttack;

	private float lastInputTime=Mathf.Infinity;

	private float[] attackDetails = new float[2];
	private Animator anim;
	private PlayerController PC;
	private PlayerStat PS;
	private void Start()
	{
		anim = GetComponent<Animator>();
		anim.SetBool("canAttack", combatEnable);
		PC = GetComponent<PlayerController>();
		PS = GetComponent<PlayerStat>();
	}

	private void Update()
	{
		CheckCombatInput();
		CheckAttacks();
	}

	private void CheckCombatInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (combatEnable)
			{
				//Attempt combat

				gotInput = true;
				lastInputTime = Time.time;
			}
		}
	}

	private void CheckAttacks()
	{
		if (gotInput)
		{
			//Perform Attack1
			if (!isAttacking)
			{
				gotInput = false;
				isAttacking = true;
				isFirstAttack = !isFirstAttack;
				anim.SetBool("attack1", true);
				anim.SetBool("firstAttack", isFirstAttack);
				anim.SetBool("isAttacking", isAttacking);

			}
		}

		if(Time.time >= lastInputTime + inputTimer)
		{
			// waiting for new input
			gotInput = false;

		}
	}
	private void CheckAttackHitBox()
	{
		Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attack1HitBoxPos.position, attack1Radius, whatIsDamageble);

		attackDetails[0] = attack1Dame;
		attackDetails[1] = transform.position.x;
		foreach (Collider2D collider in detectedObjects)
		{
			collider.transform.parent.SendMessage("Damage", attackDetails);

			//Instantiate hit particle
		}
	}

	private void FinishAttack1()
	{
		isAttacking = false;
		anim.SetBool("isAttacking", isAttacking);
		anim.SetBool("attack1", false);
	}
	private void Damage(float[] attackDetails)
	{
		if (!PC.GetDashStatus())
		{
			int direction;
			//Damage player here using attackDetails[0]
			PS.DescreaseHealth(attackDetails[0]);

			if (attackDetails[1] < transform.position.x)
			{
				direction = 1;
			}
			else
			{
				direction = -1;
			}
			PC.Knockback(direction);
		}
		
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(attack1HitBoxPos.position, attack1Radius);
	}
} 
