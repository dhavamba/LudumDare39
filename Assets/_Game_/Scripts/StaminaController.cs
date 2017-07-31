using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{ 
    [SerializeField]
    private float MAX_STAMINA;
    [SerializeField] [Range(0,1)]
    private float addStaminaSpeed;
    [SerializeField] [Range(0,1)]
    private float subStaminaSpeed;

    private ShadowAI shadow;
    private Slider slider;
    private float timeToRemaining;

    private float stamina;
    private bool isAddStamina = false; //Devo ricaricare stamina?

    CheckPointManager checkPointManager;
    
    void Start()
    {
        stamina = MAX_STAMINA;
        checkPointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
        shadow = GameObject.FindGameObjectWithTag("Shadow").GetComponent<ShadowAI>();
        slider = GameObject.FindObjectOfType<Slider>();
        timeToRemaining = MAX_STAMINA;
    }

    void Update()
    {
        if (!isAddStamina)
        {
            timeToRemaining -= Time.deltaTime * subStaminaSpeed * 50;
        }
        else
        {
            timeToRemaining += Time.deltaTime * addStaminaSpeed * 50;
        }

        timeToRemaining = Mathf.Clamp(timeToRemaining, 0, MAX_STAMINA);
        stamina = timeToRemaining;
        slider.value = stamina.ChangeRange(MAX_STAMINA, 1);

        if (stamina == 0)
        {
            //Respawno nell'ultimo checkpoint
            Respawn();
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
        slider.value = stamina.ChangeRange(MAX_STAMINA, 1);
        timeToRemaining = MAX_STAMINA;
        shadow.ResetShadow();
    }
}
