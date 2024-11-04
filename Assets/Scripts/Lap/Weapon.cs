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
        float currentTime = 0f;
        float destroyTime = 2f;

        currentTime += Time.fixedDeltaTime;

        if (currentTime == destroyTime)
        {
            Destroy(this.gameObject);
            currentTime = 0f;
            Debug.Log($"Already destroy!");
        }
    }

    public int GetShootDirection() 
    {
        return 1; 
    }
}
