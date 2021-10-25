using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Entity
{
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_PlayerDetectedState playerDetectedState { get; private set; }
    public E1_ChargeState chargeState { get; private set; }
    public E1_LookForPlayerState lookForPlayerState { get; private set; }

    [SerializeField]
    private D_IdleState idleStateData;
    [SerializeField]
    private D_MoveState moveStateData;
    [SerializeField]
    private D_PlayerDetectedState playerDetectedData;
    [SerializeField]
    private D_ChargeState chargeStateData;
    [SerializeField]
    private D_LookForPlayerState lookForPlayerStateData;

	public override void Start()
	{
		base.Start();

        moveState = new E1_MoveState(stateMachine, this, "move", moveStateData,this);
        idleState = new E1_IdleState(stateMachine, this, "idle", idleStateData, this);
        playerDetectedState = new E1_PlayerDetectedState(stateMachine, this, "playerDetected", playerDetectedData, this);
        chargeState = new E1_ChargeState(stateMachine, this, "charge", chargeStateData, this);
        lookForPlayerState = new E1_LookForPlayerState(stateMachine, this, "lookForPlayer", lookForPlayerStateData, this);

        stateMachine.Initialize(moveState);
	}
}
