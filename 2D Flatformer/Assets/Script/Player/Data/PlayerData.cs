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

    [Header("Wall Jump State")]
    public float wallJumpTime = 0.4f;
    public float wallJumpVelocity = 20f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 stopOffset;

    [Header("Dash State")]
    public float dashCooldown = .5f;
    public float maxHoldTime = 1f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30f;
    public float drag = 10f;
    public float dashEndYMultiplier = .2f;
    public float distBetweenAfterImages = 0.5f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.4f;
    public float wallCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}
