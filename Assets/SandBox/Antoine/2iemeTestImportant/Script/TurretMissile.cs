using Oculus.Interaction;
using UnityEngine;
public class TurretMissile : MonoBehaviour{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;

    private GameObject[] monstres;
    [SerializeField] public InfoTourelle infoTour;
   
    
    private AudioSource audioSource;
    
    

    void Start()
    {
        
        tourelle = GetClosestTarget();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {   
       
        
        tourelle = GetClosestTarget();

       if(tourelle != null) { 
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
            monstres = GameObject.FindGameObjectsWithTag("Monster");

            if(monstres.Length == 0){
            
        
                return null;
                
            }

            Transform closestTarget = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject potentialTarget in monstres){
                if (potentialTarget != null){
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
    private void fire(Transform tourelle){
       
        GameObject missile = Instantiate(infoTour._Projectile, canon.position, teteTourelle.rotation);
        missile.GetComponent<MissileGuide>().cible = tourelle.gameObject;
        missile.GetComponent<MissileGuide>().StartMovement();

        //MissileGuide missile = clone.GetComponent<MissileGuide>();

        //missile.cible = tourelle.gameObject;
        //StartCoroutine(missile.EnvoiMissile(clone));
        audioSource.Play();
    }

   




}