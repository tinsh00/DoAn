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

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackCounter];
      
        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);
            
        }

        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {
            
            item.Knockback(details.knockbackAngle, details.knockbackStrength, core.Movement.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if(damageable != null)
        {
            i++;
            detectedDamageables.Add(damageable);
            Debug.Log("damage" + i);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if(knockbackable != null)
        {
            j++;
            detectedKnockbackables.Add(knockbackable);
            Debug.Log("knockback" + j);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            i--;
            detectedDamageables.Remove(damageable);
            Debug.Log("damage -" + i);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            j--;
            Debug.Log("damage -" + j);
            detectedKnockbackables.Remove(knockbackable);
        }
    }
   
}
