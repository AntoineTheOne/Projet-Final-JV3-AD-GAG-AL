using UnityEngine;
public class TurretMissile : MonoBehaviour
{

    Transform joueur;
    public float dist;
    public float maxRange;
    [SerializeField] private GameObject _Projectile;
    public Transform teteTourelle, canon;
    public float fireRate, nextFire;
    private GameObject[] joueurs;

    void Start()
    {
        joueurs = GameObject.FindGameObjectsWithTag("Monster");
        joueur = GetClosestTarget();
    }

    void Update()
    {
        joueur = GetClosestTarget();

        if (joueur != null)
        {
            dist = Vector3.Distance(joueur.position, transform.position);

            if (dist <= maxRange)
            {
                teteTourelle.LookAt(joueur);

                if (Time.time >= nextFire)
                {
                    nextFire = Time.time + 1f / fireRate;
                    fire(joueur);
                }
            }
        }
    }
    private Transform GetClosestTarget()
        {
            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in joueurs)
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
    private void fire(Transform target)
    {
       
        GameObject clone = Instantiate(_Projectile, canon.position, teteTourelle.rotation);

       
        MissileGuide missile = clone.GetComponent<MissileGuide>();
        if (missile != null)
        {
            missile.cible = target.gameObject;
            StartCoroutine(missile.EnvoiMissile(clone)); 
        }
    }

    
}