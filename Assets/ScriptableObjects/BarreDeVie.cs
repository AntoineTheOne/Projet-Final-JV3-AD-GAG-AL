using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BarreDeVie", menuName = "HP/BarreDeVie")]
public class BarreDeVie : ScriptableObject
{
    public float _maxHealth = 25f;
    public float _damage;
}
