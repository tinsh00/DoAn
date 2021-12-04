using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    
    public Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool InventoryInput { get; private set; }
    public bool PauseInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    public bool ShieldInput { get; private set; }
    public bool ShieldInputStop { get; private set; }


    public bool[] AttackInputs { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;
    
    //public float ShieldInputHoldTime = 7f;

    private float jumpInputStartTime;
    private float dashInputStartTime;
    public float shieldInputStartTime;
    //private float shieldColdDownStartTime;

    //private float ShieldColdDown=3f;
   // private string attackVoice = "MeleeAttack";
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        int count = Enum.GetValues(typeof(CombatInputs)).Length;
        AttackInputs = new bool[count];
        Debug.Log(count);
        cam = Camera.main;
        InventoryInput = false;
        PauseInput = false;
        //shieldColdDownStartTime = -3f;
    }

    private void Update()
    {
		CheckJumpInputHoldTime();
		CheckDashInputHoldTime();
		//CheckShieldInputHoldTime();
	}

	public void OnKnifeAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.knife] = true;
            
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.knife] = false;
        }
    }
    public void  OnDefenseInput(InputAction.CallbackContext context)
	{
        
            if (context.started)
            {
                ShieldInput = true;
                shieldInputStartTime = Time.time;
                AttackInputs[(int)CombatInputs.defense] = true;
            }
            

            if (context.canceled)
            {
                ShieldInput = false;
               
                AttackInputs[(int)CombatInputs.defense] = false;
            }
        
        
        
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
		if (context.started)
		{
			AttackInputs[(int)CombatInputs.primary] = true;

		}

		if (context.canceled)
		{
			AttackInputs[(int)CombatInputs.primary] = false;
		}
	}

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInputs[(int)CombatInputs.secondary] = true;
        }

        if (context.canceled)
        {
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
		// Debug.Log(RawMovementInput);
		NormInputX = Mathf.RoundToInt(RawMovementInput.x);
		NormInputY = Mathf.RoundToInt(RawMovementInput.y);
		//Move();

	}
 //   public void Move()
	//{
 //       NormInputX = Mathf.RoundToInt(RawMovementInput.x);
 //       NormInputY = Mathf.RoundToInt(RawMovementInput.y);
 //   }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnInventoryInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InventoryInput = !InventoryInput;
        }

    }
    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            PauseInput = !PauseInput;
        }

    }


    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }

        if (context.canceled)
        {
            GrabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (context.canceled)
        {
            DashInputStop = true;
        }
    }

    public void OnDashDirectionInput(InputAction.CallbackContext context)
    {
		RawDashDirectionInput = context.ReadValue<Vector2>();

		if (playerInput.currentControlScheme == "Keyboard" && cam)
		{
			RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
		}

		DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
        //Debug.Log("Dash : "+DashDirectionInput);
		//DashDirectionInput = Vector2Int.RoundToInt(RawMovementInput.normalized);
		//DashDirectionInput = Vector2Int.RoundToInt(new Vector2(NormInputX,NormInputY));

    }

    public void UseJumpInput() => JumpInput = false;

    public void UseDashInput() => DashInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    //private void CheckShieldInputHoldTime()
    //{
    //    if (Time.time >= shieldInputStartTime + ShieldInputHoldTime && ShieldInput)
    //    {
    //        ShieldInput = false;
    //        //shieldColdDownStartTime = Time.time;
    //    }


    //}
    private void CheckDashInputHoldTime()
    {
        if(Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}

public enum CombatInputs
{
    primary,
    secondary,
    defense,
    knife
}
