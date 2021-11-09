using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private bool isRepawn;
    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;

    private GameManager GM;
    protected override void Awake()
	{
		base.Awake();

		currentHealth = maxHealth;
      
    }
	private void Start()
	{
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

	public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Health is zero!!");

            Die();
        }
    }
    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private void Die()
    {
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
		if(isRepawn)
        {
            GM.Respawn();
		}
        DestroyPlayer();
    }
	public override void DestroyPlayer()
	{
		base.DestroyPlayer();
	}
}
