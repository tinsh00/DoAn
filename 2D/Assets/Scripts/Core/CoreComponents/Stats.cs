using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stats : CoreComponent
{
 //   //PlayerData 
 //   [SerializeField]
 //   private float maxExp;
 //   [SerializeField]
 //   private float amountExp;
 //   public float currentExp = 0;
 //   public float coin = 0;
 //   public float level = 0;

	//[SerializeField]
	//private Text LevelText;
	//[SerializeField]
	//private ExpBar expSlider;
	//[SerializeField]
	//private Text coinText;
	//public float 
	[SerializeField] protected float maxHealth;
    public float currentHealth;

    [SerializeField]
    protected bool isRepawn;
    [SerializeField]
    protected bool isPlayer;
    protected bool isDead;
    [SerializeField]
    protected GameObject
        deathChunkParticle,
        deathBloodParticle;
    [SerializeField]
    protected GameObject hitParticle;
    [SerializeField]
    protected GameObject coinGO;
    [SerializeField]
    protected GameObject expGO;

    

    protected float TimeStartDie;
    protected float TimeToDie = .3f;
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
            
            
		}
        healthBar.SetMaxHealth(maxHealth);
        //expSlider.SetExp(currentExp);
        //coinText.text = "X" + coin;
        //LevelText.text = "lV." + level;
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
        healthBar.SetHealth(currentHealth);

    }

    public virtual void Died()
	{
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);

        if (!isPlayer && expGO && coinGO)
        {
            Instantiate(expGO, new Vector3(transform.position.x + Random.Range(-10, 10) / 100, transform.position.y, transform.position.z), expGO.transform.rotation);
            Instantiate(coinGO, new Vector3(transform.position.x + Random.Range(-10, 10) / 100, transform.position.y, transform.position.z), expGO.transform.rotation);
        }
        if (isRepawn)
        {
            GM.Respawn();
        }
        
        core.DestroyPlayer();
		
    }
	//public void IncreateExp(float amount)
	//{
	//	if (!isPlayer)
	//	{
	//		currentExp = Mathf.Clamp(currentExp + amount, 0, maxExp);
	//		expSlider.SetExp(currentExp);
            

	//		if (currentExp >= maxExp)
	//		{
	//			level++;
	//			LevelText.text = "LV." + level;
	//			currentExp = 0;
	//			expSlider.SetExp(currentExp);
	//			currentHealth = maxHealth;
	//			healthBar.SetHealth(currentHealth);
	//		}

	//	}
	//}
	//public void IncreateCoin(float amount)
	//{
	//	if (!isPlayer)
	//	{
	//	    coin += amount;
	//	    coinText.text = "X" + coin;

	//	}
	//}
	//public void DecreateCoin(float amount)
	//{
	//	if (!isPlayer)
	//	{
	//	    if (coin < amount)
	//	    {
	//		    return;
	//	    }
	//	    else
	//		    coin -= amount;
	//	    coinText.text = "X" + coin;

	//	}

	//}

}
