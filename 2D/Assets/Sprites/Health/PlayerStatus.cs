using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : Stats
{
	
	[SerializeField]
	private float maxExp;
	public float currentExp = 0;
	public float coin = 0;
	public float level = 0;
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

	}

	public override void Died()
	{
		base.Died();
		
	}

	public override void IncreaseHealth(float amount)
	{
		base.IncreaseHealth(amount);
	}

	public override void LogicUpdate()
	{
		base.LogicUpdate();
	}

	public override void Start()
	{
		base.Start();
		expSlider.SetExp(currentExp);
		coinText.text = "X" + coin;
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
			currentExp = Mathf.Clamp(currentExp + amount, 0, maxExp);
			expSlider.SetExp(currentExp);

			if (currentExp >= maxExp)
			{
				level++;
				LevelText.text = "LV." + level;
				currentExp = 0;
				expSlider.SetExp(currentExp);
				currentHealth = maxHealth;
				healthBar.SetHealth(currentHealth);
			}

		}
	}
	public void IncreateCoin(float amount)
	{
		coin += amount;
		coinText.text = "X" + coin;
	}
	public void DecreateCoin(float amount)
	{
		if (coin < amount)
		{
			return;
		}
		else
			coin -= amount;
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
		level = data.level;
		currentHealth = data.health;
		coin = data.coin;

		Vector3 position;
		position.x = data.position[0];
		position.y = data.position[1];
		position.z = data.position[2];
		
		transform.position = position;
		Debug.Log(position);
	}

}
