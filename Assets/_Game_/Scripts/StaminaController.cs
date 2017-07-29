using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{ 
    public float MAX_STAMINA;
    public float addStaminaSpeed;
    public float subStaminaSpeed;

    float timer = 1;
    float timeToRemaining;

    float stamina;
    bool isAddStamina = false; //Devo ricaricare stamina?
    
    void Start()
    {
        stamina = MAX_STAMINA;
    }

    void Update()
    {
        if (timeToRemaining <= 0)
        {
            if (!isAddStamina && stamina > 0)
            {
                stamina -= subStaminaSpeed;
                Debug.Log("Perdo stamina...  Stamina attuale: " + stamina);
            }
            else if(stamina < MAX_STAMINA)
            {
                stamina += addStaminaSpeed;

                if(stamina>MAX_STAMINA)
                {
                    stamina = MAX_STAMINA;
                }

                Debug.Log("Ricarico stamina...  Stamina attuale: " + stamina);
            }
            timeToRemaining = timer;
        }

        timeToRemaining -= Time.deltaTime;
    }

    public void setStamina(bool value)//Se passo true ricarico, se passo false scarico
    {
        isAddStamina = value;
    }
}
