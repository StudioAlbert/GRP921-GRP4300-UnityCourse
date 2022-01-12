using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, ITakeDamage, IHasHealth
{
    private int _health;
    public void initHealth()
    {
        _health = 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = 5;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int _damage)
    {
        _health -= _damage;
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
