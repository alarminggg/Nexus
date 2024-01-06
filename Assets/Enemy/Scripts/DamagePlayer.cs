using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]
    float rawDamage = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerObject")
        {
            Debug.Log("Player touched acid!");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Hit(rawDamage);
            }
        }
    }
}
