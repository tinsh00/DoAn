using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="newPlayerData",menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;


    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int amountOfJump = 1;

    [Header("In Air State")]
    public float coyoteTime = .2f;
    public float variableJumpHeightMultiplier = .5f;


    //[Header("")]
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3f;


    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3f;

    [Header("Check Variables")]
    public float groundCheckRadius = .3f;
    public float wallCheckDistance = .5f;
    public LayerMask whatIsGround;
}
