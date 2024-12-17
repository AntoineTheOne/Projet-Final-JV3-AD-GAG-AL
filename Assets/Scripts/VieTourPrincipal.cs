using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VieTourPrincipal : MonoBehaviour
{
   
    private float nbDeVieTourPrincipal;
    [SerializeField] private InfoTourPrincipal infoTourPrincipal;
    [SerializeField] private InfoDegat infoDegat;

    [SerializeField] private string sceneName;





    void Start()
    {
        nbDeVieTourPrincipal = infoTourPrincipal.vieTourPrincipal;
    }

  
    void Update()
    {
        if (nbDeVieTourPrincipal <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName);

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "monster")
        {
            nbDeVieTourPrincipal -= infoDegat.degatMonstre1;
        }
    }
}
