﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable
{
    [SerializeField]
    private float maxKnockbackTime = 0.2f;
    private bool isKnockbackActive;
    private float knockbackStartTime;
	

	
	public override void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
		if (core)
		{
            Debug.Log(core.transform.parent.name + " Damaged!");
            core.Stats.DecreaseHealth(amount);

		}
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        if(core)
		{
            core.Movement.SetVelocity(strength, angle, direction);
            core.Movement.CanSetVelocity = false;
            isKnockbackActive = true;
            knockbackStartTime = Time.time;

            core.PlayerSP.color = Color.red;
        }        
    }

    private void CheckKnockback()
    {
        if(isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && (core.CollisionSenses.Ground || Time.time >= knockbackStartTime + maxKnockbackTime))
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
            core.PlayerSP.color = core.color;
        }
    }
    private void Blink()
	{
		while (!isKnockbackActive)
		{
            core.PlayerSP.color = Color.red;
            
		}
	}
}
