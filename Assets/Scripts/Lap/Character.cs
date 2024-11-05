using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private int health;
    public int Health
    { 
        get { return health; }
        set { health = value; }
    }

    public HealthBar healthBar;

    public void Init(int newHealth)
    {
        Health = newHealth;

        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public Animator anime;
    public Rigidbody2D rb;

    public bool IsDead()
    {
      if (Health <= 0) 
      { 
            Destroy(this.gameObject);
            return true;
      }
      else return false; 
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        healthBar.UpdateHealthBar(Health);

        Debug.Log($"Character takes {damage}! Remaining Health = {Health}.");

        IsDead();
    }
}
