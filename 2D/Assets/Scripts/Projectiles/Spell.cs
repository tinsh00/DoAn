using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{

    [SerializeField]
    private LayerMask whatIsPlayer;

	public Animator Anim { get; private set; }
	public float DamageAmount;

	protected bool isAnimationFinished;
	protected bool isExitingState;

	protected float startTime;

	private void Start()
	{
		Anim = GetComponent<Animator>();
		EnterAttack();
	}
	private void Update()
	{
		
	}

	private void EnterAttack()
	{
		DoChecks();

		Anim.SetBool("spell", true);
		startTime = Time.time;
		//Debug.Log(animBoolName);
		isAnimationFinished = false;
		isExitingState = false;
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
		if (isAnimationFinished)
		{
			ExitAttack();
		}
	}
	public void PhysicsUpdate()
	{
		DoChecks();
		

	}
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.tag == "Player")
		{
			Player.instance.playerStatus.DecreaseHealth(DamageAmount);
		}
	}
	public  void DoChecks() { }
	public  void AnimationTrigger() { }

	public  void AnimationFinishTrigger() => isAnimationFinished = true;
}
