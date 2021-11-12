using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AggressiveWeapon : Weapon
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;

    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    int i = 0;
    int j = 0;
    protected override void Awake()
    {
        base.Awake();

        if(weaponData.GetType() == typeof(SO_AggressiveWeaponData))
        {
            aggressiveWeaponData = (SO_AggressiveWeaponData)weaponData;
        }
        else
        {
            Debug.LogError("Wrong data for the weapon");
        }
        
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();
        Debug.Log("star action");
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];

        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {

            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
        }
        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
            
        }

        
    }

    public void AddToDetected(Collider2D collision)
    {
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();
        
        if (knockbackable != null)
        {
            i++;
            detectedKnockbackables.Add(knockbackable);
            Debug.Log("knock + " + i);
        }
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            j++;
            detectedDamageables.Add(damageable);
            Debug.Log("dame + " + j);
        }

        
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            i--;
            detectedKnockbackables.Remove(knockbackable);
            Debug.Log("knock + " + i);
        }
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            j--;
            detectedDamageables.Remove(damageable);
            Debug.Log("damage + " + j);
        }

        
    }
   
}
