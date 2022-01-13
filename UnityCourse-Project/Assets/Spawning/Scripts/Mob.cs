using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{

    private int health = 10;
    public int Health => health; 

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Mob health" + health);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

}
