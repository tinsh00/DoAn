using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newHurtStateData", menuName = "Data/State Data/Hurt State")]
public class D_HurtState : ScriptableObject
{
    public float timeToHurt = .5f;
}
