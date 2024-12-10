using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimerTrooper = 3;
    [SerializeField] private float spawnTimerRange = 5;
    [SerializeField] private float spawnTimerHealer = 10;
    [SerializeField] private GameObject trooper;
    [SerializeField] private GameObject range;
    [SerializeField] private GameObject healer;
    private float timerTrooper;
    private float timerRange;
    private float timerHealer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    public void SpawnTroopers(){
        Instantiate(trooper);
        timerTrooper = 0;
    }
    public void SpawnRange(){
        Instantiate(range);
        timerRange= 0;
    }
    public void SpawnHealer(){
        Instantiate(healer);
        timerHealer = 0;
    }
}
