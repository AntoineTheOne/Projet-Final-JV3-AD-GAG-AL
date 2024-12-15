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

    float timerTrooper;
    float timerRange;
    float timerHealer;


    // Update is called once per frame
    void Update()
    {
        timerTrooper += Time.deltaTime;
        timerRange += Time.deltaTime;
        timerHealer += Time.deltaTime;

        if(timerTrooper > spawnTimerTrooper){
            SpawnTroopers();
        }

        else if(timerRange > spawnTimerRange){
            SpawnRange();
        }

        else if(timerHealer >spawnTimerHealer){
            SpawnHealer();
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
}