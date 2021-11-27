using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShieldAnimationToWeapon : MonoBehaviour
{
    private Shield shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GetComponentInParent<Shield>();
    }
    private void AnimationFinishParryState()
    {
        shield.FinishAnimationParry();

    }
}
