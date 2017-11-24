using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * NPCharacter.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 23
 * 
 */

[AddComponentMenu("GDC/Character/NPC")]
public class NPCharacter : Character
{
    /* Public Variables */
    public float followDistance = 1; // How close will our NPC follow player?
    [Range(0, 0.9999f)]
    public float attackDelay = 0;

    public bool isTriggered = false;
    public bool isRanged = false;

    /* Private Variables */
    private float rng_detection = 1; // How far can emeny detect something?
    private float rng_atk = 1; // How far can enemy attack? (Override value from weapon however)
    private float attackSpeed = 0;
    private float nextAttack = 0;

    private bool attacked = false;

    private GameObject followTarget, attackTarget;

    /* Getter and Setter */
    public float FollowDist
    {
        get { return followDistance; }
        set { followDistance = value; }
    }

    public float DetectionRange
    {
        get { return rng_detection; }
        set { rng_detection = value; }
    }

    public float AttackRange
    {
        get { return rng_atk; }
        set { rng_atk = value; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = 1 / (1 - value); }
    }

    public GameObject FollowTarget
    {
        get { return followTarget; }
        set { followTarget = value; }
    }

    public GameObject AttackTarget
    {
        get { return attackTarget; }
        set { attackTarget = value; }
    }

    public bool Attacked
    {
        get { return attacked; }
        set { attacked = value; }
    }

    public bool IsTriggered
    {
        get { return isTriggered; }
        set { isTriggered = value; }
    }

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake(); // Since we are overcasting Character Awake function, need to call it.
        Chartype = CharType.NPC; // Need to make sure our NPC is N.P.C!

        if (Equipped is Weapon) // Does NPC have weapon?
        {
            Weapon p = Equipped as Weapon; // Get weapon detail

            if (Equipped is RangedWeapon) // Is it ranged weapon?
            {
                isRanged = true; // Set range flag to true
                DetectionRange = p.Range; // Set detection Range as weapon's range
                AttackRange = p.Range; // Set attack range as weapon's range as well
            }
            else // Otherwise detection range needs to be manually changed
            {
                AttackRange = p.Range;
            }

            AttackSpeed = attackDelay;
        }
    }

    public override void Update()
    {
        // Non-movement functions only please
        if (FollowTarget != null) // If target to follow is not null, calculate heading and distance
            Follow();

        if (!attacked && AttackTarget != null)
            AttackRangeCheck();

        if(attacked)
        {
            nextAttack += Time.deltaTime;
            if(nextAttack >= AttackSpeed)
            {
                Attacked = false;
                nextAttack = 0;
            }
        }
    }

    public override void FixedUpdate()
    {
        if(IsTriggered) // Move only if we are triggered
            Move();
    }

    public override void OnTriggerStay2D(Collider2D collision)
    {
        // Enemy First, then player
        if(collision.gameObject.tag.Equals("Enemy"))
        {
            if(!IsTriggered)
            {
                IsTriggered = true;
                FollowTarget = collision.gameObject;
                AttackTarget = collision.gameObject;
            }
        }
        else if (collision.gameObject.tag.Equals("Player")) // Is it player?
        {
            if(!isTriggered)
            {
                isTriggered = true;
                FollowTarget = collision.gameObject;
            }
        }
    }

    public override void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) // Is it player?
        {
            IsTriggered = false;
            FollowTarget = null; // No target to follow
        }
        else if(collision.gameObject.tag.Equals("Enemy"))
        {
            IsTriggered = false;
            FollowTarget = null;
            AttackTarget = null;
        }
    }

    /* Functions */
    public virtual void Follow() // Its virtual. If Enemy class have more complex function, override it.
    {
        Vector2 dist = FollowTarget.transform.position - transform.position; // How far am I?

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

    public virtual void AttackRangeCheck()
    {
        Vector2 dist = AttackTarget.transform.position - transform.position; // Get distance between NPC and target
        if(dist.magnitude <= AttackRange) // Is target within attack range?
        {
            attacked = true;
            Attack(AttackTarget.GetComponent<Character>()); // Attack target!
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
