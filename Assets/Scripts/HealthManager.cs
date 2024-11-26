using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public BarreDeVie barreDeVie;
    [SerializeField] private Image[] currentHealth;

    private void Start()
    {
        MaxHealth(25f);
    }
    public void MaxHealth(float maxHealth){
        maxHealth = barreDeVie._maxHealth;
        Debug.Log("max health: " + maxHealth);
    }
}
