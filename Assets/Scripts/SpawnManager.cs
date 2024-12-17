using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{

[SerializeField] private float spawnTimerTrooper = 3;
[SerializeField] private float spawnTimerRange = 5;
[SerializeField] private float spawnTimerHealer = 10;
 [SerializeField] private GameObject trooper;
 [SerializeField] private GameObject range;
 [SerializeField] private GameObject healer;
[SerializeField] private float minEdgeDistance = 0.3f;

public MRUKAnchor.SceneLabels spawnLabels;
public float normalOffset;

[SerializeField] private int enemiDejaApparu = 0;

float timerTrooper;
float timerRange;
float timerHealer;
float vagueFini = 0;

[SerializeField] int enemiesPerWave = 15; //nb maximal d'ennemis en jeu
[SerializeField] int waveOffset = 5; //nb d'ennemis en plus a chaque vague
int ennemisEnJeu; //nb d'ennemis en jeu

 bool isWaiting; //Savoir si on est en pause ou non



public int spawnTry;

private void Update() {

    if(vagueFini == 5){
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }

    ennemisEnJeu = GameObject.FindGameObjectsWithTag("Monster").Length;


    if(isWaiting){
             return;
         }


    if(!MRUK.Instance && MRUK.Instance.IsInitialized)
        return;

    
        if(ennemisEnJeu <= enemiesPerWave && enemiDejaApparu < enemiesPerWave){
            timerTrooper += Time.deltaTime;
            timerRange += Time.deltaTime;
            timerHealer += Time.deltaTime;
            Debug.Log("ennemis en jeu: " + ennemisEnJeu);

            if(timerTrooper > spawnTimerTrooper && ennemisEnJeu < enemiesPerWave){
                SpawnTroopers();
                enemiDejaApparu++;
            }

            else if(timerRange > spawnTimerRange && ennemisEnJeu < enemiesPerWave){
                SpawnRange();
                enemiDejaApparu++;
            }

            else if(timerHealer >spawnTimerHealer && ennemisEnJeu < enemiesPerWave){
                SpawnHealer();
                enemiDejaApparu++;
            }
        }

        else if(ennemisEnJeu == 0 && enemiDejaApparu == enemiesPerWave){
            StartCoroutine(WaitBeforeSpawning());
        }

        else{
            return;
        }
    }

   public void SpawnTroopers(){

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        
        int currentTry = 0;

    while(currentTry < spawnTry){

    
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

            if(hasFoundPosition){
                Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
                randomPositionNormalOffset.y = 0;
                timerTrooper = 0;
                Instantiate(trooper, randomPositionNormalOffset, Quaternion.identity);  

                return;
            }
            else{
                currentTry++;
                Debug.Log("je ne fonctionne pas" + currentTry);
            }
        
        
        
     }

}



public void SpawnRange(){

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        
        int currentTry = 0;

    while(currentTry < spawnTry){

    
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

            if(hasFoundPosition){
                Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
                randomPositionNormalOffset.y = 0;
                
                Instantiate(range, randomPositionNormalOffset, Quaternion.identity);  
                timerRange = 0;
                return;
            }
            else{
                currentTry++;
                Debug.Log("je ne fonctionne pas" + currentTry);
            }
        
        
        
     }

}



public void SpawnHealer(){

        MRUKRoom room = MRUK.Instance.GetCurrentRoom();
        
        int currentTry = 0;

    while(currentTry < spawnTry){

    
        bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.VERTICAL, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

            if(hasFoundPosition){
                Vector3 randomPositionNormalOffset = pos + norm * normalOffset;
                randomPositionNormalOffset.y = 0;
                
                Instantiate(healer, randomPositionNormalOffset, Quaternion.identity);  
                timerHealer = 0;
                return;
            }
            else{
                currentTry++;
                Debug.Log("je ne fonctionne pas" + currentTry);
            }
        
        
        
     }

}








IEnumerator WaitBeforeSpawning()
    {
        isWaiting = true;
        Debug.Log("5 secondes avant la prochaine vague");
        yield return new WaitForSeconds(5);
        enemiesPerWave += waveOffset; //<-- Incrementation pour plus d'ennemis
        isWaiting = false;
        enemiDejaApparu = 0;
        vagueFini++;


    }



}
