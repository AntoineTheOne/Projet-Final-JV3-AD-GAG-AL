using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public BarreDeVie barreDeVie;
    public void MaxHealth(float maxHealth){
        maxHealth = barreDeVie._maxHealth;
        Debug.Log(maxHealth);
    }
}
