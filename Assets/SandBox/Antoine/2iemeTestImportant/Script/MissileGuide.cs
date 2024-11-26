using System.Collections;
using UnityEngine;

public class MissileGuide : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject cible;
    [SerializeField] private InfoMissile infoMissile;


    public IEnumerator EnvoiMissile(GameObject rocket)
    {

    
        while (Vector3.Distance(cible.transform.position, rocket.transform.position) > 0.3f)
        {
           
            rocket.transform.position += (cible.transform.position - rocket.transform.position).normalized * infoMissile.speed * Time.deltaTime;

          
            rocket.transform.LookAt(cible.transform);

            yield return null;
        }

        
        Destroy(rocket);
    }
}