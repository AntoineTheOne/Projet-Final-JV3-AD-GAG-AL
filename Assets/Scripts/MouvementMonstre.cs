using UnityEngine;
using UnityEngine.AI;

public class MouvementMonstre : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public float speed = 1;




    void Update()
    {
        GameObject tourProche = TrouverTourLaPlusProche();

        if (tourProche != null)
        {
            agent.SetDestination(tourProche.transform.position);
            agent.speed = speed;
        }
    }

    private GameObject TrouverTourLaPlusProche()
    {
        GameObject[] tours = GameObject.FindGameObjectsWithTag("Tourelle");
        GameObject tourProche = null;
        float distanceMin = Mathf.Infinity;

        foreach (GameObject tour in tours)
        {
            float distance = Vector3.Distance(transform.position, tour.transform.position);
            if (distance < distanceMin)
            {
                distanceMin = distance;
                tourProche = tour;
            }
        }

        return tourProche;
    }
}