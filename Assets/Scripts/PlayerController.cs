/*
 * PlayerController.cs
 * 
 * Created By: Joseph Brewster
 * Created On: 2017 Oct 13
 * Last Edited By: Joseph Brewster
 * Last Edited On: 2017 Nov 16
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("GDC/Scripts/PlayerController.cs")]
public class PlayerController : MonoBehaviour {
    [Range(5.0f, 10.0f)]
    public float forceMove = 1.0f;
    public bool facingRight = true;
    [Range (50f, 200f)]
    public float jumpForce = 100.0f;
    bool inAir = false;
    bool jumped = false;

    private Rigidbody2D body;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    
    private void FixedUpdate()
    {
        float force_horizontal = Input.GetAxis("Horizontal");
        float force_vertical = Input.GetAxis("Vertical");

        anim.SetFloat("Speed", Mathf.Abs(force_horizontal));

        if (force_horizontal > 0 && !facingRight)
            Flip();
        else if (force_horizontal < 0 && facingRight)
            Flip();
        
        Vector2 force = new Vector3(force_horizontal * forceMove,  force_vertical * forceMove);

        body.AddForce(force);

        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            body.AddForce(Vector3.up* jumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
      
        if (collision.collider.gameObject.tag.Equals("Ground"))
            if (jumped)
                jumped = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.gameObject.tag.Equals("Ground"))
            if (!jumped)
                jumped = true;
    }
    

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
