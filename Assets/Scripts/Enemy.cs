using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 10
 * 
 */

[AddComponentMenu("GDC/Character/Enemy")]
public class Enemy : NPCharacter
{
    /* Public Variables */
    public bool isRanged = false;
    public bool isTriggered = false;

    /* Private Variables */
    private float rng_detection = 1; // How far can emeny detect something?
    private float rng_atk = 1; // How far can enemy attack? (Override value from weapon however)

    /* Getter and Setters */
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

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
        Chartype = CharType.ENEMY; // Set self as enemy

        if(Equipped is Weapon) // Does enemy have weapon?
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
        }
    }

    public override void Update()
    {
        base.Update();
    }

    /* Functions */
    public override void Follow(Transform target)
    {
        if(isTriggered) // Is enemy triggered?
            base.Follow(target); // Refer to NPCharacter.Follow()
    }

    public override void Attack(Character target)
    {
        // Attack only if target is not enemy
        if(target.Chartype != CharType.NONE && target.Chartype != CharType.ENEMY)
            base.Attack(target);
    }

    public override void Jump()
    {
        base.Jump();
    }
}
