using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed = 10;
    public float shootingCooldown = 1.5f;

    private float cooldownTimer;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.Mouse0) && cooldownTimer <= 0f)
        {
            var projectile = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = ProjectileSpawnPoint.forward * ProjectileSpeed;

            cooldownTimer = shootingCooldown;
        }
    }
}
