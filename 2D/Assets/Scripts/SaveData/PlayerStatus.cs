using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : Stats
{
	
	[SerializeField]
	public float maxExp;
	public float currentExp;
	public float coin;
	public float level;

	public PlayerStatus(float currentExp, float coin, float level)
	{
		this.currentExp = currentExp;
		this.coin = coin;
		this.level = level;
	}

	[SerializeField]
	public Text LevelText;
	[SerializeField]
	public ExpBar expSlider;
	[SerializeField]
	public Text coinText;



	public override void DecreaseHealth(float amount)
	{
		base.DecreaseHealth(amount);
		//healthBar.SetHealth(currentHealth);

	}

	public override void Died()
	{
		base.Died();
		
	}

	public override void IncreaseHealth(float amount)
	{
		base.IncreaseHealth(amount);
		//healthBar.SetHealth(currentHealth);
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
	}

	public override void Start()
	{
		base.Start();
		//SaveDPlayer();
		//LoadDPlayer();
		isPlayer = true;
		
		currentExp = Inventory.instance.currentExp;
		expSlider.SetExp(currentExp);		
		coin = Inventory.instance.coin;
		coinText.text = "X" + coin;
		level = Inventory.instance.level;
		LevelText.text = "lV." + level;
	}

	public override void Update()
	{
		base.Update();
	}

	protected override void Awake()
	{
		base.Awake();
		

	}

	public void IncreateExp(float amount)
	{
			Inventory.instance.IncreaseCurExp(amount);
			currentExp = Inventory.instance.currentExp;
			expSlider.SetExp(currentExp);
			level = Inventory.instance.level;
			LevelText.text = "LV." + level;
			//currentHealth = maxHealth;
			healthBar.SetHealth(currentHealth);
	}
	public void IncreateCoin(float amount)
	{
		Inventory.instance.IncreaseCoin(amount);
		coin = Inventory.instance.coin;
		coinText.text = "X" + coin;
	}
	public void DecreateCoin(float amount)
	{
		Inventory.instance.DecreaseCoin(amount);
		coin = Inventory.instance.coin;
		coinText.text = "X" + coin;

	}

}
