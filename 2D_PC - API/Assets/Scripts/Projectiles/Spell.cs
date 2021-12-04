using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{

    [SerializeField]
    private LayerMask whatIsPlayer;

	public Animator Anim { get; private set; }
	public float DamageAmount;
	[SerializeField]
	private float damageRadius;
	public Transform damagePosition;

	protected bool isAnimationFinished;
	protected bool isExitingState;
	protected bool enterAttack;
	protected bool isDamage;
	protected bool isDamaged;
	IDamageable damageableTemp=null;

	protected float startTime;
	string spellVoice = "spell";

	private void Start()
	{
		Anim = GetComponent<Animator>();
		Anim.SetBool("spell", true);
		startTime = Time.time;
		//Debug.Log(animBoolName);
		isAnimationFinished = false;
		isExitingState = false;
		AudioManager.instance.PlaySound(spellVoice);
		enterAttack = false;
		isDamage = false;
		isDamaged = false;
		//EnterAttack();
	}
	private void Update()
	{
		
	}

	public void EnterAttack()
	{
		DoChecks();
		Collider2D[] PlayerHits = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsPlayer);
		
		foreach (Collider2D collider in PlayerHits)
		{
			IDamageable damageable = collider.GetComponent<IDamageable>();

			if (damageable != null)
			{
				damageableTemp = damageable;
				isDamage = true;
			}

			//IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

			//if (knockbackable != null)
			//{
			//	knockbackable.Knockback(Vector2.one, 10f, leftOnPlayer);
			//}
		}
		if (damageableTemp != null && isDamage && !isDamaged)
		{
			damageableTemp.Damage(DamageAmount);
			isDamage = false;
			isDamaged = true;
		}	
		//Anim.SetBool("spell", true);
		//startTime = Time.time;
		////Debug.Log(animBoolName);
		//isAnimationFinished = false;
		//isExitingState = false;
		//AudioManager.instance.PlaySound(spellVoice);
	}
	private void ExitAttack()
	{
		Anim.SetBool("spell", false);
		isExitingState = true;
		Destroy(gameObject);
	}
	public void LogicUpdate()
	{
		
	}
	private void FixedUpdate()
	{
		if (enterAttack)
			EnterAttack();

		if (isAnimationFinished)
		{
			ExitAttack();
		}



	}
	public void PhysicsUpdate()
	{
		DoChecks();
		

	}
	
	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if (collision.transform.tag == "Player")
	//	{
	//		IDamageable damageable = collision.GetComponent<IDamageable>();
	//		if (damageable != null)
	//		{
	//			damageable.Damage(DamageAmount);
	//			//Destroy(gameObject);
	//		}
	//		//Player.instance.playerStatus.DecreaseHealth(DamageAmount);
	//	}
	//}
	public  void DoChecks() { }
	public void AnimationEnter() => enterAttack = true;
	public void AnimationExit() => enterAttack = false;
	public  void AnimationFinishTrigger() => isAnimationFinished = true;

	private void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
	}
}
