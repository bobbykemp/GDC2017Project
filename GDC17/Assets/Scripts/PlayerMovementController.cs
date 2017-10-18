using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerMovementController.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Oct 17
 * 
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Oct 17
 * 
 * Player movement controller for left, right, and jump
 * 
 */
[AddComponentMenu("GDC/Scripts/Player Movement Controller.cs")]
public class PlayerMovementController : MonoBehaviour
{
    /* Public variables */
    [Range(1.0f, 50.0f)]
    public float velocity = 1.0f;

    /* Private variables */
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    private bool isFacingRight = true;

    private void Awake()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void UpdateHorizontal()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 vel = Vector2.right * velocity * horizontal;
        vel.y += body.velocity.y;
        if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
        else if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }

        body.velocity = vel;
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = this.transform.localScale;

        scale.x *= -1;
        this.transform.localScale = scale;
    }

    private void FixedUpdate()
    {
        UpdateHorizontal();
    }
}
