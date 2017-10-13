/* 
 * Created by:	Joshua Gibbs
 * Created on:	October 12, 2017
 * 
 * Modified by:
 * Modified on:
 * 
 * This is a demo of how the health gauge would work.
 */

using UnityEngine;
using System.Collections;

public class HealthDemo : MonoBehaviour
{
	public DebugReportSender	console;

	private bool			started = false;
	private GaugeController	gauge;

	void Start ()
	{
		/* 
		 * Because gague is defined using an interface type, it will not show up in the inspector when set to public.
		 * To work around this, I tagged the health gauge with "Health" and use these two lines of code to get the controller for the health guage.
		 */
		GameObject healthObject = GameObject.FindGameObjectWithTag ("Health");
		gauge = healthObject.GetComponent<GaugeController> ();
	}

	void Update ()
	{
		// Start the demo if it has not already been started.
		if (!started)
		{
			started = true;
			StartCoroutine (RunDemo ());
		}
	}
		
	private IEnumerator RunDemo ()
	{
		console.SendLog ("Starting health demo.");
		console.SendLog ("The player will have 100 health.");
		// Sends a description of what will heppen to the gauge then performs that action.
		console.SendLog ("Oh no. The player got hit by an enemy for 50 damage.");
		gauge.ModifyValue (-50.0f);
		yield return new WaitForSeconds (2.0f);
		console.SendLog ("Yay! The player found a health potion. They drank it and gained 25 health points");
		gauge.ModifyValue (25.0f);
		yield return new WaitForSeconds (2.0f);
		console.SendLog ("It turned out that the potion belonged to a really tough monster. He hit the player for 80 damage.");
		gauge.ModifyValue (-80f);
		yield return new WaitForSeconds (2f);
		console.SendLog ("But the powers that be had mercy on the player and revived the player to full health.");
		gauge.ModifyValue (1000000f);
	}
}
