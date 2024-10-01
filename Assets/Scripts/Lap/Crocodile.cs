using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocodile : Enemy
{
    private float attackRange;
    private Player player;

    private void Start()
    {
        Init(100);
        Debug.Log($"Ant's Hp = {Health}");

        Behaviour();
    }

    public override void Behaviour()
    {
        Debug.Log("CrocoDile.Behaviour");
    }
}
