using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    protected D_MeleeAttack stateData;

    private Animator anim;

    [SerializeField]
    private string playerHurt = "playerHurt";
    [SerializeField]
    private string shieldHitClip = "shieldHit";
    public MeleeAttackState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData) : base(etity, stateMachine, animBoolName, attackPosition)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPosition.position, stateData.attackRadius, stateData.whatIsPlayer);
        Collider2D shieldHit = Physics2D.OverlapCircle(attackPosition.position, stateData.attackRadius, stateData.whatIsShield);
        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if(damageable != null)
            {
                damageable.Damage(stateData.attackDamage);
                AudioManager.instance.PlaySound(playerHurt);
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if(knockbackable != null)
            {
                knockbackable.Knockback(stateData.knockbackAngle, stateData.knockbackStrength, core.Movement.FacingDirection);
            }
        }
		if (shieldHit)
		{
            //Debug.Log(shieldHit.gameObject.name);
            shieldHit.gameObject.transform.parent.gameObject.SendMessage("SetShieldHitMeleeAttack", true);
            AudioManager.instance.PlaySound(shieldHitClip);
		}
		
    }
}
