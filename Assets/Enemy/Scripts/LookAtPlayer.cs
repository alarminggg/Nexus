using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemy;

    [SerializeField] private float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;
    public GameObject spawnPoint;
    public float enemySpeed;
    public float stoppingDistance = 15f;
    public float maxFollowDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= maxFollowDistance)
            {
                if (distanceToPlayer > stoppingDistance)
                {
                    enemy.SetDestination(player.position);
                }
                else
                {
                    enemy.ResetPath();

                    Vector3 directionToPlayer = player.position - transform.position;
                    directionToPlayer.y = 0;
                    Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, Time.deltaTime * 5.0f);
                }
                ShootAtPlayer();
            }
        }
        
        
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0)
        {
            return;
        }

        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemySpeed);
        Destroy(bulletObj, 5f);
    }
}
