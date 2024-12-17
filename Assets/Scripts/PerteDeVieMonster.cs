using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerteDeVieMonster : MonoBehaviour
{
    private float nbDeVieMonster;
    [SerializeField] private InfoMonster infoMonster;
    [SerializeField] private InfoDegat infoDegat;
    




    // Start is called before the first frame update
    void Start()
    {
        nbDeVieMonster = infoMonster.vieInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if(nbDeVieMonster <= 0){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            nbDeVieMonster -= infoDegat.degatLaser;
        }
        
        if(collision.gameObject.tag == "Missile")
        {
            nbDeVieMonster -= infoDegat.degatMissile;
        }
        if (collision.gameObject.tag == "Sniper")
        {
            nbDeVieMonster -= infoDegat.degatSniper;
        }
    }



}
