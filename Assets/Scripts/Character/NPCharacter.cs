using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NPCharacter.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 17
 * 
 */

[AddComponentMenu("GDC/Character/NPC")]
public class NPCharacter : Character
{
    /* Public Variables */
    public float followDistance = 1; // How close will our NPC follow player?
    public bool isTriggered = false;

    /* Getter and Setter */
    public float FollowDist
    {
        get { return followDistance; }
        set { followDistance = value; }
    }

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake(); // Since we are overcasting Character Awake function, need to call it.
        Chartype = CharType.NPC; // Need to make sure our NPC is N.P.C!
    }

    public virtual void Update()
    {
        // Non-movement functions only please
    }

    public virtual void FixedUpdate()
    {
        if(isTriggered) // Move only if we are triggered
            Move();
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) // Is it player?
        {
            if(!isTriggered)
                isTriggered = true;
            Follow(collision.transform); // Follow player
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) // Is it player?
            isTriggered = false;
    }

    /* Functions */
    public virtual void Follow(Transform target) // Its virtual. If Enemy class have more complex function, override it.
    {
        Vector2 dist = target.position - transform.position; // How far am I?

        if (dist.magnitude > FollowDist) // Am I too far from target?
        {
            int dir = dist.x > 0 ? 1 : -1; // Set direction
            H_CurrSpeed = dir * H_Speed; // Add speed towards target!
        }
        else // I'm close enough with target
        {
            H_CurrSpeed = 0; // Set speed to 0
        }
    }

    public override void Attack(Character target)
    {
        if(target.Chartype == CharType.ENEMY) // Attack if and only if target character is enemy
            base.Attack(target);
    }

    public override void Jump()
    {
        base.Jump();
    }
}
