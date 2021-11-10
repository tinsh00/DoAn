using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    [SerializeField]
    private bool isRepawn;
    private bool isDead;
    [SerializeField]
    private GameObject
        deathChunkParticle,
        deathBloodParticle;
    [SerializeField]
    private GameObject hitParticle;


    private float TimeStartDie;
    private float TimeToDie = .5f;

    private GameManager GM;
    protected override void Awake()
	{
		base.Awake();

		currentHealth = maxHealth;
      
    }
	private void Start()
	{
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentHealth = maxHealth;
        isDead=false;
        
    }
	private void Update()
	{
		
        if (isDead && Time.time >= TimeStartDie + TimeToDie)
        {
            Died();
        }
    }

	public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        Instantiate(hitParticle, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f)));

        //Instantiate(hitParticle, alive.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 180.0f)));
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Health is zero!!");

            isDead = true;
            
                core.PlayerSP.color = Color.red;
                core.Movement.SetVelocityZero();
                TimeStartDie = Time.time;

            
        }

    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private void Die()
    {
       
		
        
    }
    private void Died()
	{
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        if (isRepawn)
        {
            GM.Respawn();
        }
        core.DestroyPlayer();
    }
	
}
