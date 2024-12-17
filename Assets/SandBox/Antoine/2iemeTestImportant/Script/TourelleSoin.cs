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
        Debug.Log(tourelle);
        
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
                Debug.Log("fonctionne pas 1");
            }
            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in tourelleTableau)
            {
                if (potentialTarget.GetComponent<TurretMissile>().canHeald == true){
                    Debug.Log("fonctionne pas 2");
                    float distanceToTarget = Vector3.Distance(transform.position, potentialTarget.transform.position);
                    if (distanceToTarget < closestDistance){
                        Debug.Log("fonctionne pas 3");
                        closestTarget = potentialTarget.transform;
                        closestDistance = distanceToTarget;
                    }
                }
            }
            return closestTarget;
        }
    private void fire(Transform tourelle)
    {

        GameObject missile = Instantiate(infoTour._Projectile, canon.position, teteTourelle.rotation);
        missile.GetComponent<MissileGuide>().cible = tourelle.gameObject;
        missile.GetComponent<MissileGuide>().StartMovement();

        //MissileGuide missile = clone.GetComponent<MissileGuide>();

        //missile.cible = tourelle.gameObject;
        //StartCoroutine(missile.EnvoiMissile(clone));
    }

    void verificationPlusDevie(){
        if(pointdeVieTourelle == 0){
         Destroy(gameObject);
        }
    }



}