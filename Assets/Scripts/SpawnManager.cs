using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTimerTrooper = 3;
    [SerializeField] private float spawnTimerRange = 5;
    [SerializeField] private float spawnTimerHealer = 10;
    [SerializeField] private GameObject trooper;
    [SerializeField] private GameObject range;
    [SerializeField] private GameObject healer;
    [SerializeField] private Transform[] spawnPoint;

    [SerializeField] private int enemiAuTotal = 0;

    float timerTrooper;
    float timerRange;
    float timerHealer;

    //Systeme de vagues d'ennemis
    [SerializeField] int enemiesPerWave = 15; //nb maximal d'ennemis en jeu
    [SerializeField] int waveOffset = 5; //nb d'ennemis en plus a chaque vague
    int ennemisEnJeu; //nb d'ennemis en jeu
    
    bool isWaiting; //Savoir si on est en pause ou non
    


    // Update is called once per frame
    void Update()
    {
        ennemisEnJeu = GameObject.FindGameObjectsWithTag("Monster").Length; //<-- Changer ici pour le bon tag

        if(isWaiting){
            return;
        }

        if(ennemisEnJeu <= enemiesPerWave && enemiAuTotal < enemiesPerWave){
            timerTrooper += Time.deltaTime;
            timerRange += Time.deltaTime;
            timerHealer += Time.deltaTime;
            Debug.Log("ennemis en jeu: " + ennemisEnJeu);

            if(timerTrooper > spawnTimerTrooper && ennemisEnJeu < enemiesPerWave){
                SpawnTroopers();
                enemiAuTotal++;
            }

            else if(timerRange > spawnTimerRange && ennemisEnJeu < enemiesPerWave){
                SpawnRange();
                enemiAuTotal++;
            }

            else if(timerHealer >spawnTimerHealer && ennemisEnJeu < enemiesPerWave){
                SpawnHealer();
                enemiAuTotal++;
            }
        }

        else if(ennemisEnJeu == 0 && enemiAuTotal == enemiesPerWave){
            StartCoroutine(WaitBeforeSpawning());
        }

        else{
            return;
        }
    }

    void SpawnTroopers(){
        int randomPoint = Random.Range(0, spawnPoint.Length);
        Instantiate(trooper, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
        timerTrooper = 0;
    }
    void SpawnRange(){
        int randomPoint = Random.Range(0, spawnPoint.Length);
        Instantiate(range, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
        timerRange= 0;
    }
    void SpawnHealer(){
        int randomPoint = Random.Range(0, spawnPoint.Length);
        Instantiate(healer, spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
        timerHealer = 0;
    }

    IEnumerator WaitBeforeSpawning()
    {
        isWaiting = true;
        Debug.Log("5 secondes avant la prochaine vague");
        yield return new WaitForSeconds(5);
        enemiesPerWave += waveOffset; //<-- Incrementation pour plus d'ennemis
        isWaiting = false;
        enemiAuTotal = 0;
    }
}