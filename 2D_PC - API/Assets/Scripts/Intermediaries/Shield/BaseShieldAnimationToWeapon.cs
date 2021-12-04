using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShieldAnimationToWeapon : MonoBehaviour
{
    private Shield shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = GetComponentInParent<Shield>();
    }

	private void AnimationFinishEnterState()
	{

        shield.AnimationFinishEnterState();

    }
    private void AnimationFinishTrigger()
    {
        shield.AnimationFinishTrigger();
    }
 
    private void AnimationStartMovementTrigger()
    {
        shield.AnimationStartMovementTrigger();
    }

    private void AnimationStopMovementTrigger()
    {
        shield.AnimationStopMovementTrigger();
    }

    private void AnimationTurnOffFlipTrigger()
    {
        shield.AnimationTurnOffFlipTrigger();
    }

    private void AnimationTurnOnFlipTrigger()
    {
        shield.AnimationTurnOnFlipTigger();
    }

    private void AnimationActionTrigger()
    {
        shield.AnimationActionTrigger();
    }
}
