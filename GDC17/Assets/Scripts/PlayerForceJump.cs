/*
 * PlayerForceJump.cs
 * Created By: Connor Morris
 * Created On: 2017 Oct 11
 * Last Edited By: Connor Morris
 * Last Edited On: 2017 Oct 11
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Player/PlayerForceJump")]
public class Player : MonoBehaviour {
    [Range(250.0f, 1000.0f)]
    public float jumpForce = 250.0f; //haven't actually checked how much force this causes, don't have a player/ground
    private Rigidbody2D body;
    private bool jumped;

    private void Awake()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (Input.GetKeyUp("space") && !jumped) //is space currently defined in the input?
        {
            body.AddForce(Vector2.up * jumpForce);
        }
    }
    /* //don't know what the layers are set to
    private void OnCollisionStay(Collision collision) {
        if(collision.collider.gameObject.layer == #### && collision.collider.gameObject.tag.Equals("AAAAA"))
        {
            if (jumped)
            {
                jumped = false;
            }    
        }
    }

    private void OnCollisionExit(Collision collision) {
        if(collision.collider.gameObject.layer == #### && collision.collider.gameObject.tag.Equals("AAAAA"))
        {
            if (!jumped)
            {
                jumped = true;
            }
        }
    }
    */
}
