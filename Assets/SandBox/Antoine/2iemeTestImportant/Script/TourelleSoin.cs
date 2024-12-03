using UnityEngine;
public class TourelleSoin : MonoBehaviour
{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;

    private GameObject[] tourelleTableau;
    [SerializeField] private InfoTourelle infoTour;
    [SerializeField] private GameObject boutonRecharger;
    private int munitionEnReserve;
    
    private int pointdeVieTourelle;
    [SerializeField] private GameObject pointDeSoin;

    void Start()
    {
        
        tourelle = GetClosestTarget();
        munitionEnReserve = infoTour.munitionEnReserveInitial;
        pointdeVieTourelle = infoTour.pointDeVie;
    }

    void Update()
    {
        if(pointdeVieTourelle < infoTour.pointDeVie){
            pointDeSoin.SetActive(true);
        } else{
            pointDeSoin.SetActive(false);
            
        }
        
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
        munitionEnReserve = infoTour.munitionEnReserveInitial;
    }


    private Transform GetClosestTarget()
        {
            tourelleTableau = GameObject.FindGameObjectsWithTag("Tourelle");
            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in tourelleTableau)
            {
                if (potentialTarget != null && potentialTarget.GetComponent<TurretMissile>().canHeald == true)
               // if (potentialTarget != null)
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