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

    void OnCollisionEnter(Collision collision)
    {
       Destroy(gameObject);
    }

}