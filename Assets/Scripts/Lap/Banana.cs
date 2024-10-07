using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField]private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Init(30);
        speed = 4f;
        Move();
    }

    public override void OnHitWith(Character character)
    {

    }

    public override void Move()
    {
        Debug.Log($"Banana moves by Transform at constant speed.");
    }
}
