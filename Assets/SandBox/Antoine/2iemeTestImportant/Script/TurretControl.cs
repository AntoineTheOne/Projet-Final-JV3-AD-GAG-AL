using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    public float vitesse = 2000f;
    Transform player;
    public float dist;
    public float maxRange;
    [SerializeField] private GameObject _Projectile;
    public Transform  headTurret, barrel;
    public float fireRate, nextFire;
     private GameObject[] players;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Monster");
        player = GetClosestTarget();
    }

    void Update()
    {
        player = GetClosestTarget();

        if (player != null)
        {
            dist = Vector3.Distance(player.position, transform.position);

            if (dist <= maxRange)
            {
                headTurret.LookAt(player);

                if (Time.time >= nextFire)
                {
                    nextFire = Time.time + 1f / fireRate;
                    Shoot();
                }
            }
        }
    }


    private void Shoot()
    {
        GameObject clone = Instantiate(_Projectile, barrel.position, headTurret.rotation);
        clone.GetComponent<Rigidbody>().AddForce(headTurret.forward * vitesse);
        Destroy(clone, 10);
    }


    private Transform GetClosestTarget()
    {
        Transform closestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject potentialTarget in players)
        {
            if (potentialTarget != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.transform.position);

                if (distanceToTarget < closestDistance)
                {
                    closestTarget = potentialTarget.transform;
                    closestDistance = distanceToTarget;
                }
            }
        }

        return closestTarget;
    }
}
