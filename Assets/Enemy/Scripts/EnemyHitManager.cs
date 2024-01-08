using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{
    [SerializeField] float maxhealth = 50f;
    float currentHealth;


    void Start()
    {
        currentHealth = maxhealth;
    }

    void Update()
    {
        
    }

    public void TakeDamage(float enemyDamage)
    {
        currentHealth -= enemyDamage;

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
