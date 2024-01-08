using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    public Transform ProjectileSpawnPoint;
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed = 10;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.T))
        {
            var projectile = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, ProjectileSpawnPoint.rotation);
            projectile.GetComponent<Rigidbody>().velocity = ProjectileSpawnPoint.forward * ProjectileSpeed;
        }
    }
}
