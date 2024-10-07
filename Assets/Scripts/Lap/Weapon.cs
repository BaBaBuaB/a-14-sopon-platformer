using System.Collections;
using System.Collections.Generic;
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
    public int GetShootDirection() 
    {
        return 1; 
    }
}
