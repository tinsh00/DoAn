using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Entity
{   
    public E2_MoveState moveState { get; private set; }
    public E2_IdleState idleState { get; private set; }
    public E2_PlayerDetectedState playerDetectedState { get; private set; }
    public E2_MeleeAttackState meleeAttackState { get; private set; }
    public E2_LookForPlayerState lookForPlayerState { get; private set; }
    public E2_StunState stunState { get; private set; }
    public E2_DeadState deadState { get; private set; }
    public E2_DodgeState dodgeState { get; private set; }
    public E2_RangedAttackState rangedAttackState { get; private set; }
    public E2_HurtState hurtState { get; private set; }

    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_PlayerDetected playerDetectedStateData;
    [SerializeField]
    private D_MeleeAttack meleeAttackStateData;
    [SerializeField]
    private D_LookForPlayer lookForPlayerStateData;
    [SerializeField]
    private D_StunState stunStateData;
    [SerializeField]
    private D_DeadState deadStateData;
    [SerializeField]
    public D_DodgeState dodgeStateData;
    [SerializeField]
    private D_RangedAttackState rangedAttackStateData;
    [SerializeField]
    private D_HurtState hurtStateData;

    [SerializeField]
    private Transform meleeAttackPosition;
    [SerializeField]
    private Transform rangedAttackPosition;

    [SerializeField]
    private string deadVoice = "deadPlayer"; 
    [SerializeField]
    private string hurtVoice = "hurtPlayer";

    public Stats stats;
    

    public override void Awake()
    {
        base.Awake();
        
        moveState = new E2_MoveState(this, stateMachine, "move", moveStateData, this);
        idleState = new E2_IdleState(this, stateMachine, "idle", idleStateData, this);
        playerDetectedState = new E2_PlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedStateData, this);
        meleeAttackState = new E2_MeleeAttackState(this, stateMachine, "meleeAttack", meleeAttackPosition, meleeAttackStateData, this);
        lookForPlayerState = new E2_LookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerStateData, this);
        stunState = new E2_StunState(this, stateMachine, "stun", stunStateData, this);
        deadState = new E2_DeadState(this, stateMachine, "dead", deadStateData, this);
        dodgeState = new E2_DodgeState(this, stateMachine, "dodge", dodgeStateData, this);
        rangedAttackState = new E2_RangedAttackState(this, stateMachine, "rangedAttack", rangedAttackPosition, rangedAttackStateData, this);
        hurtState = new E2_HurtState(this, stateMachine, "hurt", hurtStateData, this);

    }
	public override void Update()
	{
		base.Update();
		if (stats.currentHealth <= 0.0f)
		{
            stateMachine.ChangeState(deadState);
            AudioManager.instance.PlaySound(deadVoice);
            Player.instance.quest.goal.EnemyKilled();
        }
        else if (stats.currentHealth <= 20.0f && stateMachine.currentState != stunState)
        {
            stateMachine.ChangeState(stunState);
        }
        else if (stats.hurt)
		{
            stateMachine.ChangeState(hurtState);
            AudioManager.instance.PlaySound(hurtVoice);
		}
    }
	private void Start()
    {
        stateMachine.Initialize(moveState);        
    }
    
	
    
	public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireSphere(meleeAttackPosition.position, meleeAttackStateData.attackRadius);
    }
    private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

    private void AnimtionFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
