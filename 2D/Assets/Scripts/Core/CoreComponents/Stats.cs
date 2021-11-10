using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : CoreComponent
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    [SerializeField]
    protected bool isRepawn;
    protected bool isDead;
    [SerializeField]
    protected GameObject
        deathChunkParticle,
        deathBloodParticle;
    [SerializeField]
    protected GameObject hitParticle;



    protected float TimeStartDie;
    protected float TimeToDie = .5f;
    [SerializeField]
    protected HealthBar healthBar;

    protected GameManager GM;
    protected override void Awake()
	{
		base.Awake();

	
    }
	public virtual void Start()
	{
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (!healthBar)
		{
            healthBar = GameObject.Find("Health Bar").GetComponent<HealthBar>();
            healthBar.SetMaxHealth(maxHealth);

		}
        currentHealth = maxHealth;
        isDead=false;
        
        
    }
	public virtual void Update()
	{
        
        if (isDead && Time.time >= TimeStartDie + TimeToDie)
        {
            Died();
        }
    }

	public virtual void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
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

    public virtual void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        

    }

    private void Die()
    {
       
		
        
    }
    public virtual void Died()
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
