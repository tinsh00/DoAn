using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;
	// Start is called before the first frame update
	public void SetExp(float exp)
	{
		slider.value = exp;		
	}
}
