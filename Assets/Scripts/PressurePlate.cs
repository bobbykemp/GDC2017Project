using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PressurePlate.cs
 * 
 * Created By: Bobby Kemp
 * Created On: 2017 Nov 28
 * Last Edited By: Bobby Kemp
 * Last Edited On: 2017 Nov 30
 * 
 */

[AddComponentMenu("GDC/World/Object/Pressure Plate")]

public class PressurePlate : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Something entered the trigger");
	}

	void OnTriggerStay2D(Collider2D other)
	{
		Debug.Log ("Something is in the trigger");
	}

	void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log ("Something left the trigger");
	}
}
