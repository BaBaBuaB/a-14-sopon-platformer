using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Weapon
{
    [SerializeField]private float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 4f * GetShootDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
        {
            character.TakeDamage(this.Damage); 
        }
    }

    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;

        Vector2 newPosition = new Vector2(newX, newY);

        transform.position = newPosition;

    }
}
