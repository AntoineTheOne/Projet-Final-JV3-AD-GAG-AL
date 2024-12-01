using UnityEngine;
public class TurretMissile : MonoBehaviour
{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;
    public int munitionEnReserve = 50;
    private GameObject[] monstres;
    [SerializeField] private InfoTourelle infoTour;
    [SerializeField] private GameObject boutonRecharger;
    

    void Start()
    {
        monstres = GameObject.FindGameObjectsWithTag("Monster");
        tourelle = GetClosestTarget();
    }

    void Update()
    {
        tourelle = GetClosestTarget();

        
            dist = Vector3.Distance(tourelle.position, transform.position);

            if (dist <= infoTour.maxRange)
            {
                teteTourelle.LookAt(tourelle);

                if (Time.time >= nextFire && munitionEnReserve != 0)
                {
                    nextFire = Time.time + 1f / infoTour.fireRate;
                    fire(tourelle);
                    munitionEnReserve --;
                }
                if(munitionEnReserve == 0){
                    boutonRecharger.SetActive(true);
                }
            }
        
    }

    public void RechargementMunition(){
        munitionEnReserve = infoTour.MunitionEnReserveInitial;
    }


    private Transform GetClosestTarget()
        {
            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in monstres)
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
    private void fire(Transform tourelle)
    {
       
        GameObject clone = Instantiate(infoTour._Projectile, canon.position, teteTourelle.rotation);

       
        MissileGuide missile = clone.GetComponent<MissileGuide>();
        
            missile.cible = tourelle.gameObject;
            StartCoroutine(missile.EnvoiMissile(clone)); 
        
    }

    
}