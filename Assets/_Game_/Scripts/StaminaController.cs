using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{ 
    public float MAX_STAMINA;
    public float addStaminaSpeed;
    public float subStaminaSpeed;
    ShadowAI shadow;

    float timer = 3;
    float timeToRemaining;

    float stamina;
    bool isAddStamina = false; //Devo ricaricare stamina?

    CheckPointManager checkPointManager;
    
    void Start()
    {
        stamina = MAX_STAMINA;
        checkPointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
        shadow = GameObject.FindGameObjectWithTag("Shadow").GetComponent<ShadowAI>();
    }

    void Update()
    {
        if (timeToRemaining <= 0)
        {
            if (!isAddStamina && stamina > 0)
            {
                if (stamina > 0)
                {
                    stamina -= subStaminaSpeed;
                    Debug.Log("Perdo stamina...  Stamina attuale: " + stamina);
                }
                else
                {
                    //Respawno nell'ultimo checkpoint
                    stamina = 0;
                }
            }
            if(isAddStamina && stamina < MAX_STAMINA)
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
        if (stamina <= 0)
        {
            //Respawno nell'ultimo checkpoint
           // Respawn();
        }
    }

    public void setStamina(bool value)//Se passo true ricarico, se passo false scarico
    {
        isAddStamina = value;
    }

    public float getStamina()
    {
        return stamina;
    }

    public void Respawn()
    {
        
        this.transform.position = checkPointManager.getCheckPoint().position;
        stamina = MAX_STAMINA;
        timeToRemaining = timer;
        shadow.ResetShadow();
    }
}
