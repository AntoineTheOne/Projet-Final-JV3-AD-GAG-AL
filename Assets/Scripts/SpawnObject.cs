using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
 [SerializeField] GameObject tourelle;
 [SerializeField] Transform parent;
 public Vector3 newPosition;

 public Quaternion newRotation;


public void InstantiatePatate(){
    Instantiate(tourelle,parent );
}
}
