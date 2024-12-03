using UnityEngine;
public class TurretMissile : MonoBehaviour
{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;

    private GameObject[] monstres;
    [SerializeField] private GameObject pointDeSoin;
    [SerializeField] public InfoTourelle infoTour;
    [SerializeField] private GameObject boutonRecharger;
    private int munitionEnReserve;
    public int pointdeVieTourelle;
    public bool canHeald;

    
    

    void Start()
    {
        
        tourelle = GetClosestTarget();
        munitionEnReserve = infoTour.munitionEnReserveInitial;
        pointdeVieTourelle = infoTour.pointDeVie;
        
    }

    void Update()
    {

        if(pointdeVieTourelle < infoTour.pointDeVie){
            canHeald = true;
        } else{
            canHeald = false;
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
            monstres = GameObject.FindGameObjectsWithTag("Monster");
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

    void OnCollisionEnter(Collision collision){
        Debug.Log("je marche");
        pointdeVieTourelle += 1;
    }





}