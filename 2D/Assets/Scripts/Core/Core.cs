using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public CollisionSenses CollisionSenses
    {
        get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }
    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }
    public Stats Stats
	{
        get => GenericNotImplementedError<Stats>.TryGet(stats, transform.parent.name);
        private set => stats = value;
	}
    public SpriteRenderer PlayerSP
	{
        get => GenericNotImplementedError<SpriteRenderer>.TryGet(playerSP, transform.parent.name);
        private set => playerSP = value;
    }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;
    public Stats stats;
    private SpriteRenderer playerSP;
    public Color color;

    private List<ILogicUpdate> components = new List<ILogicUpdate>();

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Combat = GetComponentInChildren<Combat>();
        stats = GetComponentInChildren<Stats>();
        playerSP = GetComponentInParent<SpriteRenderer>();
        color = PlayerSP.color;
    }

    public void LogicUpdate()
    {
        foreach (ILogicUpdate component in components)
        {
            component.LogicUpdate();
        }
    }

    public void AddComponent(ILogicUpdate component)
    {
        //Check to make sure components is not already part of the list - .Contains() comes from the Linq library
        if (!components.Contains(component))
        {
            components.Add(component);
        }
    }
    public void DestroyPlayer()
	{
        Destroy(transform.parent.gameObject);
	}
   
    

}
