using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDeadToStatemachine : MonoBehaviour
{
    public DeadState deadState;
	private void Start()
	{
        deadState = GetComponent<DeadState>();
    }

	private void AnimationDeadTrigger()
    {
        deadState.AnimationTrigger();
    }

    private void AnimationDeadFinishTrigger()
    {
        deadState.AnimationFinishTrigger();
    }
}
