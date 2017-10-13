/* 
 * Created by:	Joshua Gibbs
 * Created on:	October 13, 2017
 * 
 * Modified by:
 * Modified on:
 * 
 * This script conrtols how the health slider changes its current value.
 */

using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, GaugeController
{
	public Slider healthSlider;

	public bool ModifyValue (float changeAmount)
	{
		/*
		 * This checks if the the gauge is at the max vaule and if the changeAmount is positive.
		 * If both are true, then the health will not change since it is at the max value.
		 */
		if (healthSlider.value == healthSlider.maxValue && Mathf.Sign (changeAmount) >= 0)
		{
			return false;
		}
		/*
		 * This checks if the the gauge is at the min vaule and if the changeAmount is negative.
		 * If both are true, then the health will not change since it is at the minimum value.
		 */
		else if (healthSlider.value == healthSlider.minValue && Mathf.Sign (changeAmount) < 0)
		{
			return false;
		}

		// If the script reaches this point, then it means the slider's current value will change.
		healthSlider.value += changeAmount;
		return true;
	}
}
