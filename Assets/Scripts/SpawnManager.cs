using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
[SerializeField] private float minEdgeDistance = 0.3f;

public MRUKAnchor.SceneLabels spawnLabels;
public float normalOffset;
[SerializeField] private float vagueFini = 0;

[SerializeField] private int enemiDejaApparu = 0;

int ennemisEnJeu; //nb d'ennemis en jeu

 bool isWaiting; //Savoir si on est en pause ou non

 [SerializeField] private string sceneName;
    [SerializeField] private string sceneNameEchec;
    

private GameObject[] tourPrincipal;
public int spawnTry;

[SerializeField] private InfoNiveau infoNiveau;





    private void Start()
    {
        infoNiveau.timerTrooper = 0;
        infoNiveau.timerRange = 0;
        infoNiveau.timerHealer = 0;
    }




    private void Update() {



    tourPrincipal = GameObject.FindGameObjectsWithTag("TourPrincipal");


        if (vagueFini == infoNiveau.maxWave){
       SceneManager.LoadScene(sceneName);

    }

    ennemisEnJeu = GameObject.FindGameObjectsWithTag("Monster").Length;


    if(isWaiting){
             return;
         }

if(tourPrincipal.Length == 1){
           

            
        
    if(!MRUK.Instance && MRUK.Instance.IsInitialized)
        return;

    
        if(ennemisEnJeu <= infoNiveau.enemiesPerWave && enemiDejaApparu < infoNiveau.enemiesPerWave){
            infoNiveau.timerTrooper += Time.deltaTime;
            infoNiveau.timerRange += Time.deltaTime;
            infoNiveau.timerHealer += Time.deltaTime;
            Debug.Log("ennemis en jeu: " + ennemisEnJeu);

            if(infoNiveau.timerTrooper > infoNiveau.spawnTimerTrooper && ennemisEnJeu < infoNiveau.enemiesPerWave){
                SpawnTroopers();
                enemiDejaApparu++;
            }

            else if(infoNiveau.timerRange > infoNiveau.spawnTimerRange && ennemisEnJeu < infoNiveau.enemiesPerWave){
                SpawnRange();
                enemiDejaApparu++;
            }

            else if(infoNiveau.timerHealer > infoNiveau.spawnTimerHealer && ennemisEnJeu < infoNiveau.enemiesPerWave){
                SpawnHealer();
                enemiDejaApparu++;
            }
        }

        else if(ennemisEnJeu == 0 && enemiDejaApparu == infoNiveau.enemiesPerWave){
            StartCoroutine(WaitBeforeSpawning());
        }

        else{
            return;
        }
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
                infoNiveau.timerTrooper = 0;
                Instantiate(infoNiveau.trooper, randomPositionNormalOffset, Quaternion.identity);  

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
                
                Instantiate(infoNiveau.range, randomPositionNormalOffset, Quaternion.identity);
                infoNiveau.timerRange = 0;
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
                
                Instantiate(infoNiveau.healer, randomPositionNormalOffset, Quaternion.identity);
                infoNiveau.timerHealer = 0;
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
        infoNiveau.enemiesPerWave += infoNiveau.waveOffset; //<-- Incrementation pour plus d'ennemis
        isWaiting = false;
        enemiDejaApparu = 0;
        vagueFini++;


    }



}
