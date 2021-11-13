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
	//public float 


	[SerializeField]
	private Text LevelText;
	[SerializeField]
	private ExpBar expSlider;
	[SerializeField]
	private Text coinText;



	public override void DecreaseHealth(float amount)
	{
		base.DecreaseHealth(amount);
		healthBar.SetHealth(currentHealth);

	}

	public override void Died()
	{
		base.Died();
		
	}

	public override void IncreaseHealth(float amount)
	{
		base.IncreaseHealth(amount);
		healthBar.SetHealth(currentHealth);
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
		if (!expSlider)
		{
			expSlider = GameObject.Find("Exp Bar").GetComponent<ExpBar>();
		}
		currentExp = Inventory.instance.currentExp;
		expSlider.SetExp(currentExp);
		if (!coinText)
		{
			coinText = GameObject.Find("coinText").GetComponent<Text>();
		}
		coin = Inventory.instance.coin;
		coinText.text = "X" + coin;
		if (!LevelText)
		{
			LevelText = GameObject.Find("Level").GetComponent<Text>();
		}
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
		if (isPlayer)
		{
			Inventory.instance.IncreaseCurExp(amount);
			currentExp = Inventory.instance.currentExp;
			expSlider.SetExp(currentExp);
			level = Inventory.instance.level;
			LevelText.text = "LV." + level;
			currentHealth = maxHealth;
			healthBar.SetHealth(currentHealth);
		}
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
	public void SaveDPlayer()
	{
		SaveSystem.SavePlayer(this);
	}
	public void LoadDPlayer()
	{
		DPlayer data = SaveSystem.LoadPlayer();

		currentExp = data.exp;
		expSlider.SetExp(currentExp);
		level = data.level;
		LevelText.text = "LV." + level;
		currentHealth = data.health;
		healthBar.SetHealth(currentExp);
		coin = data.coin;
		coinText.text = "X" + coin;

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		
		transform.parent.parent.position = position;
		Debug.Log(position);
	}

}
