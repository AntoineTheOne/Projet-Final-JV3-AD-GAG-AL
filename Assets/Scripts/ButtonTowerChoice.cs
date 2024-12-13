using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTowerChoice : MonoBehaviour
{
    [SerializeField] private SpawnTower spawnTower;

    public void ChangeTower(GameObject tower)
    {
        spawnTower.towerPrefab = tower;
    }
}
