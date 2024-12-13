using UnityEngine;
public class TourelleSoin : MonoBehaviour
{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;

    private GameObject[] tourelleTableau;
    [SerializeField] private InfoTourelle infoTour;
    
    
    private int pointdeVieTourelle;
    [SerializeField] private GameObject pointDeSoin;

    void Start()
    {
        pointdeVieTourelle = infoTour.pointDeVie;
    }

    void Update()
    {

        verificationPlusDevie();
        if (pointdeVieTourelle < infoTour.pointDeVie) {
            pointDeSoin.SetActive(true); 
        } else {
            pointDeSoin.SetActive(false); 
        }
        tourelle = GetClosestTarget();
        if (tourelle != null){
            dist = Vector3.Distance(tourelle.position, transform.position);

        
            if (dist <= infoTour.maxRange){
                teteTourelle.LookAt(tourelle); 

            
                if (Time.time >= nextFire){
                    nextFire = Time.time + 1f / infoTour.fireRate;
                    
                    fire(tourelle);  
                }

            
            }
        }
    }


    private Transform GetClosestTarget(){
           tourelleTableau = GameObject.FindGameObjectsWithTag("Tourelle");
            if(tourelleTableau.Length == 0){
                return null;
            }
            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in tourelleTableau)
            {
                if (potentialTarget != null && potentialTarget.GetComponent<TurretMissile>().canHeald == true){
                    float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.transform.position);
                    if (distanceToTarget < closestDistance){
                        closestTarget = potentialTarget.transform;
                        closestDistance = distanceToTarget;
                    }
                }
            }
            return closestTarget;
        }
    private void fire(Transform tourelle){
            GameObject clone = Instantiate(infoTour._Projectile, canon.position, teteTourelle.rotation);
            MissileGuide missile = clone.GetComponent<MissileGuide>();
            missile.cible = tourelle.gameObject;
            StartCoroutine(missile.EnvoiMissile(clone)); 
    }

    void verificationPlusDevie(){
        if(pointdeVieTourelle == 0){
         Destroy(gameObject);
        }
    }



}