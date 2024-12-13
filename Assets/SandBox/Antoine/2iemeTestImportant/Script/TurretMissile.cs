using Oculus.Interaction;
using UnityEngine;
public class TurretMissile : MonoBehaviour{

    Transform tourelle;
    public float dist;
    public Transform teteTourelle, canon;
    public float nextFire;

    private GameObject[] monstres;
    [SerializeField] private GameObject pointDeSoin;
    [SerializeField] public InfoTourelle infoTour;
   
 
    public int pointdeVieTourelle;
    public bool canHeald;
    private AudioSource audioSource;
    
    

    void Start()
    {
        
        tourelle = GetClosestTarget();
        pointdeVieTourelle = infoTour.pointDeVie;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {   
        verificationPlusDevie();

        if(pointdeVieTourelle < infoTour.pointDeVie){
            canHeald = true;
        } else{
            canHeald = false;
        }
        
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

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Soin")
        {
            pointdeVieTourelle += 1;
            Debug.Log("ALLO");
        }
        
        
    }

    void verificationPlusDevie(){
        if(pointdeVieTourelle == 0){
         Destroy(gameObject);
        }
    }




}