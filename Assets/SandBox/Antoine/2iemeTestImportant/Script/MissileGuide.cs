using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileGuide : MonoBehaviour
{
    
    [SerializeField] private GameObject RocketPrefab;
    [SerializeField] private List<GameObject> spawnPoint;
    [SerializeField] private GameObject target;
    public float speed = 1f;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GameObject rocket = Instantiate(RocketPrefab, spawnPoint[Random.Range(0, 4)].transform.position, RocketPrefab.transform.rotation);
            rocket.transform.LookAt(target.transform);
            StartCoroutine(EnvoiMissile(rocket));
        }
    }



    public IEnumerator EnvoiMissile(GameObject rocket){
        while (Vector3.Distance(target.transform.position, rocket.transform.position)>0.3f){
            rocket.transform.position += (target.transform.position - rocket.transform.position).normalized * speed * Time.deltaTime;
            rocket.transform.LookAt(target.transform);
            yield return null;
        }
    }



}
