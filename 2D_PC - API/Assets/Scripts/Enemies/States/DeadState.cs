using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected D_DeadState stateData;


    public DeadState(Entity etity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData) : base(etity, stateMachine, animBoolName)
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
        isAnimationFinished = false;
        core.Movement.SetVelocityZero();

    }

    public override void Exit()
    {
       
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAnimationFinished)
        {
            if (stateData.deathBloodParticle)
                GameObject.Instantiate(stateData.deathBloodParticle, entity.transform.position, stateData.deathBloodParticle.transform.rotation);
            if (stateData.deathChunkParticle)
                GameObject.Instantiate(stateData.deathChunkParticle, entity.transform.position, stateData.deathChunkParticle.transform.rotation);
            if (stateData.coin)
                GameObject.Instantiate(stateData.coin, entity.transform.position, stateData.coin.transform.rotation);
            if (stateData.exp)
                GameObject.Instantiate(stateData.exp, entity.transform.position, stateData.exp.transform.rotation);

            Player.instance.quest.goal.EnemyKilled();
            GameObject.Destroy(entity.gameObject);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        

    }
	public override void AnimationTrigger()
	{
		base.AnimationTrigger();
	}
	public override void AnimationFinishTrigger()
	{
		base.AnimationFinishTrigger();
	}

}
