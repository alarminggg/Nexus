using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            EnemyHitManager enemyHitManager = other.gameObject.GetComponent<EnemyHitManager>();
            if (enemyHitManager != null)
            {
                enemyHitManager.TakeDamage(rawDamage);
            }
        }
    }
}
