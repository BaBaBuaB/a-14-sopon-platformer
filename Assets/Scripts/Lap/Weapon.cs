using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]private int damage;
    public int Damage 
    {  
        get { return Damage; }
        set { Damage = value; }
    }
    protected string owner;

    //public abstract void OnHitWith(Character);
    public abstract void Move();
    public int GetShootDirection() 
    {
        return 1; 
    }
}
