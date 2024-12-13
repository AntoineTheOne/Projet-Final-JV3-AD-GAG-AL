using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MissileGuide : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject cible;
    [SerializeField] private InfoMissile infoMissile;
    private bool isMovement;


    private void Update()
    {


        if (isMovement)
        {
            Debug.Log("Test: " + cible);
            if (cible == null)
            {
                Destroy(gameObject);
                return;
            }
            transform.position += (cible.transform.position - transform.position).normalized * infoMissile.speed * Time.deltaTime;
            transform.LookAt(cible.transform);
        }

    }

    public void StartMovement()
    {
        isMovement = true;
    }

    //public IEnumerator EnvoiMissile(GameObject rocket){
     
    //    if (cible == null){
    //        Destroy(rocket);  
    //        yield break;  
    //    }
    //    while (cible != null && Vector3.Distance(cible.transform.position, rocket.transform.position) > 0.3f){
    //        //if (cible == null)
    //        //{
    //        //    Destroy(rocket);  
    //        //    yield break;
    //        //}
    //        rocket.transform.position += (cible.transform.position - rocket.transform.position).normalized * infoMissile.speed * Time.deltaTime;
    //        rocket.transform.LookAt(cible.transform);
    //        yield return null;  
    //    }

    //    if(gameObject == null){
    //        yield break;
    //    }
    //    Destroy(rocket);  
    //}

    void OnCollisionEnter(Collision collision)
    {
       Destroy(gameObject);
    }

}