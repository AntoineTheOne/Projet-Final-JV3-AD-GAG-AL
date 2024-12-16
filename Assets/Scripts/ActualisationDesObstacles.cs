using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using Meta.XR.MRUtilityKit;
using System.Collections;

public class ActualisationDesObstacles : MonoBehaviour
{

    private NavMeshSurface navmeshSurface;



    // Start is called before the first frame update
    void Start()
    {
        navmeshSurface = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavmesh);
    }

    public void BuildNavmesh()
    {
        StartCoroutine(BuildNavmeshRoutine());
    }

        public IEnumerator BuildNavmeshRoutine(){
            yield return new WaitForEndOfFrame();
            navmeshSurface.BuildNavMesh();
        }
}
