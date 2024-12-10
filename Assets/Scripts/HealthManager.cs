using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public BarreDeVie barreDeVie;
    [SerializeField] private GameObject[] currentHealth;

    private void Start()
    {
        MaxHealth(25f);
    }
    private void Update()
    {
        CheckHealth();
    }
    private void MaxHealth(float maxHealth){
        maxHealth = barreDeVie._maxHealth;
        Debug.Log("max health: " + maxHealth);
    }

    void CheckHealth(){
        for( int i = 0; i <= barreDeVie._maxHealth; i++ ){
            UpdateHealth();
            Debug.Log(i);
            currentHealth[i].SetActive(true);
            
        }
    }

    void UpdateHealth(){
        foreach(GameObject frames in currentHealth){
            frames.SetActive(false);
        }
    }
}
