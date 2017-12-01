using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * MovableBox.cs
 * 
 * Created By: Bobby Kemp
 * Created On: 2017 Nov 28
 * Last Edited By: Bobby Kemp
 * Last Edited On: 2017 Nov 30
 * 
 */

[AddComponentMenu("GDC/World/Object/Movable Box")]

public class MovableBox : MonoBehaviour {

	public Rigidbody2D rb;
	public gameObject player;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
		
	void FixedUpdate()
	{
		PickupBox ();
	}

	void PickupBox()
	{
		if(Input.GetKeyDown ("e")) {
			//Debug.Log ("pressing e key");
			//rb.AddForce (transform.up * 9);
			transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
			this.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
		}
		if (Input.GetKeyUp ("e")) {
			this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
		}
	}
}
