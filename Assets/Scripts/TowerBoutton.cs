using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBoutton : MonoBehaviour
{
    [SerializeField] private SpawnTower spawnTower;


    public void SpawnBoutton(GameObject tower)
    {
        spawnTower.towerPrefab = tower;
    }
}
