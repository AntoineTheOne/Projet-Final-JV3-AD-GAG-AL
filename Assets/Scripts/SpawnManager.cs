using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{


[SerializeField] private float spawnTimer = 1;
[SerializeField] private GameObject prefabToSpawn;

[SerializeField] private float minEdgeDistance = 0.3f;

public MRUKAnchor.SceneLabels spawnLabels;
public float normalOffset;
 
private float timer;

public int spawnTry;



private void Start() {
    
}

private void Update() {


    if(!MRUK.Instance && MRUK.Instance.IsInitialized)
        return;

    
    timer += Time.deltaTime;
    if(timer > spawnTimer){
        SpawnGhost();
        timer -= spawnTimer;
    }
    }

   public void SpawnGhost(){

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        
        int currentTry = 0;

    while(currentTry < spawnTry){

    
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

            if(hasFoundPosition){
                Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
                randomPositionNormalOffset.y = 0;
                
                Instantiate(prefabToSpawn, randomPositionNormalOffset, Quaternion.identity);  

                return;
            }
            else{
                currentTry++;
                Debug.Log("je ne fonctionne pas" + currentTry);
            }
        
        
        
     }

}


}



 // ANCIENS SCRIPT PAS FONCTIONNEL AVEC LE META //

    // [SerializeField] private float spawnTimerTrooper = 3;
    // [SerializeField] private float spawnTimerRange = 5;
    // [SerializeField] private float spawnTimerHealer = 10;
    // [SerializeField] private GameObject trooper;
    // [SerializeField] private GameObject range;
    // [SerializeField] private GameObject healer;
    // [SerializeField] private Transform[] spawnPoint;

    // [SerializeField] private int enemiDejaApparu = 0;

    // float timerTrooper;
    // float timerRange;
    // float timerHealer;

    // //Systeme de vagues d'ennemis
    // [SerializeField] int enemiesPerWave = 15; //nb maximal d'ennemis en jeu
    // [SerializeField] int waveOffset = 5; //nb d'ennemis en plus a chaque vague
    // int ennemisEnJeu; //nb d'ennemis en jeu
    
    // bool isWaiting; //Savoir si on est en pause ou non
    


    // // Update is called once per frame
    // void Update()
    // {
    //     ennemisEnJeu = GameObject.FindGameObjectsWithTag("Monster").Length; //<-- Changer ici pour le bon tag

    //     if(isWaiting){
    //         return;
    //     }

    //     if(ennemisEnJeu <= enemiesPerWave && enemiDejaApparu < enemiesPerWave){
    //         timerTrooper += Time.deltaTime;
    //         timerRange += Time.deltaTime;
    //         timerHealer += Time.deltaTime;
    //         Debug.Log("ennemis en jeu: " + ennemisEnJeu);

    //         if(timerTrooper > spawnTimerTrooper && ennemisEnJeu < enemiesPerWave){
    //             SpawnTroopers();
    //             enemiDejaApparu++;
    //         }

    //         else if(timerRange > spawnTimerRange && ennemisEnJeu < enemiesPerWave){
    //             SpawnRange();
    //             enemiDejaApparu++;
    //         }

    //         else if(timerHealer >spawnTimerHealer && ennemisEnJeu < enemiesPerWave){
    //             SpawnHealer();
    //             enemiDejaApparu++;
    //         }
    //     }

    //     else if(ennemisEnJeu == 0 && enemiDejaApparu == enemiesPerWave){
    //         StartCoroutine(WaitBeforeSpawning());
    //     }

    //     else{
    //         return;
    //     }
    // }

    // void SpawnTroopers(){
    //     int randomPoint = Random.Range(0, spawnPoint.Length);
    //     Instantiate(trooper, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
    //     timerTrooper = 0;
    // }
    // void SpawnRange(){
    //     int randomPoint = Random.Range(0, spawnPoint.Length);
    //     Instantiate(range, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
    //     timerRange= 0;
    // }
    // void SpawnHealer(){
    //     int randomPoint = Random.Range(0, spawnPoint.Length);
    //     Instantiate(healer, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
    //     timerHealer = 0;
    // }

    // IEnumerator WaitBeforeSpawning()
    // {
    //     isWaiting = true;
    //     Debug.Log("5 secondes avant la prochaine vague");
    //     yield return new WaitForSeconds(5);
    //     enemiesPerWave += waveOffset; //<-- Incrementation pour plus d'ennemis
    //     isWaiting = false;
    //     enemiDejaApparu = 0;
    // }