using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]private int damage;
    public int Damage 
    {  
        get { return damage; }
        set { damage = value; }
    }
    protected string owner;

    public void Init(int _damage)
    {
      Damage = _damage;
    }
    public abstract void OnHitWith(Character character);
    public abstract void Move();

    public virtual void SelfDestroy()
    {
        float timeDestroy = 0;

        if (timeDestroy == 5f)
        {
            Destroy(gameObject);
        }

        timeDestroy += 1f;
    }

    public int GetShootDirection() 
    {
        Destroy(gameObject);
        return 1; 
        
    }
}
