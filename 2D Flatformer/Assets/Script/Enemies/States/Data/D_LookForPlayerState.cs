using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newLookForPlayerStateData", menuName = "Data/State Data/Look For Player State")]

public class D_LookForPlayerState : ScriptableObject
{
    public int amontOfTurn = 2;
    public float timeBetweenTurns = 0.75f;
}
