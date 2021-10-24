using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movementInputDirection;
    private float jumpTimer;
    private float turnTimer;
    private float wallJumpTimer;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastDash = -100f;


    private int amountOfJumpLeft;



    private int facingDirection = 1;
    private int lastWallJumpDirection;

    private bool isFacingRight = true;
    private bool isGrounded;
    private bool isWalking;
    private bool isTouchingWall;
    private bool isTouchingLedge;
    private bool isWallSliding;
    private bool canNormalJump;
    private bool canWallJump;
    private bool isAttemptingToJump;
    private bool checkJumpMultiplier;
    private bool canMove;
    private bool canFlip;
    private bool canClimbLedge = false;
    private bool ledgeDetected;
    private bool hasWallJumped;
    private bool isDashing;


    private Vector2 ledgePosBot;
    private Vector2 ledgePos1;
    private Vector2 ledgePos2;

    private Rigidbody2D rb;
    private Animator anim;

    public int amountOfJump = 1;

    public float movementSpeed = 10f;
    public float jumpForce = 16.0f;
    public float groundCheckRadius;
    public float wallCheckDistance;
    public float wallSlideSpeed;
    public float movementForceInAir;
    public float airDragMultiplier = 0.95f;
    public float variableJumpHeightMultiplier = 0.5f;
    public float wallHopForce;
    public float wallJumpForce;
    public float jumpTimerSet = 0.15f;
    public float turnTimerSet = 0.1f;
    public float wallJumpTimerSet = 0.5f;

    public float ledgeClimbXOffset1 = 0f;
    public float ledgeClimbYOffset1 = 0f;
    public float ledgeClimbXOffset2 = 0f;
    public float ledgeClimbYOffset2 = 0f;

    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCoolDown;


    public Vector2 wallHopDirection;
    public Vector2 wallJumpDirection;

    public Transform groundCheck;
    public Transform wallCheck;
    public Transform ledgeCheck;

    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        amountOfJumpLeft = amountOfJump;
        wallHopDirection.Normalize();
        wallJumpDirection.Normalize();

    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckIfCanJump();
        UpdateAnimations();
        CheckIfWallSliding();
        CheckJump();
        CheckLedgeClimb();
        CheckDash();
    }


	private void FixedUpdate()
	{
        ApplyMovement();
        CheckSurroundings();
        CheckMovementDirection();


    }
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isWallSliding", isWallSliding);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }
    private void CheckIfWallSliding()
	{
        if (isTouchingWall && movementInputDirection == facingDirection && rb.velocity.y < 0 && !canClimbLedge)  
		{
            isWallSliding = true;
		}
		else
		{
            isWallSliding = false;
		}
	}
	private void CheckIfCanJump()
	{
        if (isGrounded && rb.velocity.y <= 0.01f) 
        {
            amountOfJumpLeft = amountOfJump;
        }
		if (isTouchingWall)
		{
            canWallJump = true;
		}
		if (amountOfJumpLeft <= 0)
		{
            canNormalJump = false;
		}
        else
		{
            canNormalJump = true;
		}
	}
   
    private void CheckSurroundings()
	{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);
        isTouchingLedge = Physics2D.Raycast(ledgeCheck.position, transform.right, wallCheckDistance, whatIsGround);
        if(isTouchingWall && !isTouchingLedge && !ledgeDetected)
		{
            ledgeDetected = true;
            ledgePosBot = wallCheck.position;
		}
    
    }

    private void CheckMovementDirection()
	{
        if(isFacingRight && movementInputDirection < 0)
		{
            Flip();
		}
		else
		{
            if (!isFacingRight && movementInputDirection > 0)
                Flip();
		}

        if(rb.velocity.x != 0)
		{
            isWalking = true;
		}
		else
		{
            isWalking = false;
		}
	}

	private void Flip()
	{
		if (!isWallSliding && canFlip)
		{
            facingDirection *= -1;
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180f, 0.0f);
		}
	}

	private void CheckInput()
	{
        movementInputDirection = Input.GetAxisRaw("Horizontal");

		if (Input.GetButtonDown("Jump"))
		{
            if(isGrounded || (amountOfJumpLeft>0 && isTouchingWall))
			{
                NormalJump();
			}
			else
			{
                jumpTimer = jumpTimerSet;
                isAttemptingToJump = true;
			}
		}
        if (Input.GetButtonDown("Horizontal") && isTouchingWall) 
		{
            if(!isGrounded && movementInputDirection != facingDirection)
			{
                canMove = false;
                canFlip = false;

                turnTimer = turnTimerSet;
			}
		}
        if (turnTimer >= 0) 
		{
            turnTimer -= Time.deltaTime;
			if (turnTimer <= 0)
			{
                canMove = true;
                canFlip = true;
			}
		}
		if (checkJumpMultiplier &&  !Input.GetButton("Jump"))
		{
            checkJumpMultiplier = false;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * variableJumpHeightMultiplier);
		}

		if (Input.GetButtonDown("Dash"))
		{
            AttempToDash();
		}

	}

	private void AttempToDash()
	{
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;

        PlayerAfterImagePool.Instance.GetFromPool();
        lastImageXpos = transform.position.x;
	}

    private void CheckDash()
	{
		if (isDashing)
		{
			if (dashTimeLeft > 0)
			{
                canMove = false;
                canFlip = false;
                rb.velocity = new Vector2(dashSpeed * facingDirection, rb.velocity.y);
                dashTimeLeft -= Time.deltaTime;

                if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                {
                    PlayerAfterImagePool.Instance.GetFromPool();
                    lastImageXpos = transform.position.x;
                }
            }
            
            if(dashTimeLeft<=0 || isTouchingWall)
			{
                isDashing = false;
                canMove = true;
                canFlip = true;
			}
		}
	}

	public void FinishLedgeClimb()
    {
        canClimbLedge = false;
        transform.position = ledgePos2;
        canMove = true;
        canFlip = true;
        ledgeDetected = false;
        anim.SetBool("canClimbLedge", canClimbLedge);

    }
    private void CheckLedgeClimb()
	{
        if(ledgeDetected && !canClimbLedge)
		{
            canClimbLedge = true;
			if (isFacingRight)
			{
                ledgePos1 = new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) - ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
                ledgePos2 = new Vector2(Mathf.Floor(ledgePosBot.x + wallCheckDistance) + ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset2);
			}
            else
			{
                ledgePos1 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) + ledgeClimbXOffset1, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset1);
                ledgePos2 = new Vector2(Mathf.Ceil(ledgePosBot.x - wallCheckDistance) - ledgeClimbXOffset2, Mathf.Floor(ledgePosBot.y) + ledgeClimbYOffset2);

            }
            canMove = false;
            canFlip = false;
            anim.SetBool("canClimbLedge", canClimbLedge);
        }
		if (canClimbLedge)
		{
            transform.position = ledgePos1;
		}
	}

	private void CheckJump()
	{
		if (jumpTimer > 0)
		{
            //wallJump
            if(!isGrounded && isTouchingWall && movementInputDirection !=0 && movementInputDirection != facingDirection)
			{
                WallJump();
			}
            else if (isGrounded)
			{
                NormalJump();
			}

		}
		if(isAttemptingToJump)
		{
            jumpTimer -= Time.deltaTime;
		}
		if (wallJumpTimer > 0)
		{
            if (hasWallJumped && movementInputDirection == -lastWallJumpDirection)
			{
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
			}
            else if (wallJumpTimer <= 0)
			{
                hasWallJumped = false;

			}
			else
			{
                wallJumpTimer -= Time.deltaTime;
			}
		}
      
	}
    private void NormalJump()
	{
        if (canNormalJump || !isWallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            amountOfJumpLeft--;
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
        }
    } 
    private void WallJump()
	{
        if (canWallJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            isWallSliding = false;
            amountOfJumpLeft = amountOfJump;
            amountOfJumpLeft--;
            Vector2 forceToAdd = new Vector2(wallJumpForce * wallJumpDirection.x * movementInputDirection, wallJumpForce * wallJumpDirection.y);
            rb.AddForce(forceToAdd, ForceMode2D.Impulse);
            jumpTimer = 0;
            isAttemptingToJump = false;
            checkJumpMultiplier = true;
            turnTimer = 0;
            canMove = true;
            canFlip = true;
            hasWallJumped = true;
            wallJumpTimer = wallJumpTimerSet;
            lastWallJumpDirection = -facingDirection; 
        }
    }

	private void ApplyMovement()
	{
        if(!isGrounded && !isWallSliding && movementInputDirection == 0)
		{
            rb.velocity = new Vector2(rb.velocity.x * airDragMultiplier, rb.velocity.y);
		}
        else if(canMove)
		{
          rb.velocity  = new Vector2(movementSpeed * movementInputDirection, rb.velocity.y);
		}
       

		if (isWallSliding)
		{
			if (rb.velocity.y < -wallSlideSpeed)
			{
                rb.velocity = new Vector2(rb.velocity.x, -wallSlideSpeed);
			}
		}
	}

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(ledgeCheck.position, new Vector3(ledgeCheck.position.x + wallCheckDistance, ledgeCheck.position.y, ledgeCheck.position.z));
	}
}
