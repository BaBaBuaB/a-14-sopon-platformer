using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : Weapon
{
    [SerializeField]private Rigidbody2D rb2d;
    [SerializeField]private Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        Damage = 40;
    }

    /*public override void OnHitWith(Character)
    {

    }*/

    public override void Move()
    {
        Debug.Log($"Rock moves by Transform at constant speed.");
    }
}