using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    [SerializeField]private Rigidbody2D rb2d;
    private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        force = new Vector2 (GetShootDirection() * 100, 400);
        Move();
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
        {
            character.TakeDamage(this.Damage);
        }
    }

    public override void Move()
    {
        Debug.Log($"Rock moves by Transform at constant speed.");

        rb2d.AddForce( force );
    }
}
