using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InfoNiveau", menuName = "InfoNiveau")]
public class InfoNiveau : ScriptableObject
{

public int enemiesPerWave;
public int waveOffset;
public int maxWave;



  public float spawnTimerTrooper = 3;
  public float spawnTimerRange = 5;
  public float spawnTimerHealer = 10;

    [SerializeField] public GameObject trooper;
 [SerializeField] public GameObject range;
 [SerializeField] public GameObject healer;

 public float timerTrooper = 3;
 public  float timerRange = 5;
 public float timerHealer = 10;


}
