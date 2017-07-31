using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : Singleton<StaminaController>
{ 
    private float MAX_STAMINA;
    [SerializeField] [Range(0,1)]
    private float addStaminaSpeed;
    [SerializeField] [Range(0,1)]
    private float subStaminaSpeed;

    private ShadowAI shadow;
    private Slider slider;

    private float stamina;

    public bool isAddStamina = false; //Devo ricaricare stamina?

    private bool isDeath;

    CheckPointManager checkPointManager;
    
    void Start()
    {
        MAX_STAMINA = 100;
        stamina = MAX_STAMINA;
        checkPointManager = GameObject.FindGameObjectWithTag("CheckPointManager").GetComponent<CheckPointManager>();
        shadow = GameObject.FindGameObjectWithTag("Shadow").GetComponent<ShadowAI>();
        slider = GameObject.FindObjectOfType<Slider>();
        stamina = MAX_STAMINA;
    }

    void Update()
    {
        if (!isAddStamina)
        {
            stamina -= Time.deltaTime * subStaminaSpeed * 50;
        }
        else
        {
            stamina += Time.deltaTime * addStaminaSpeed * 50;
        }

        stamina = Mathf.Clamp(stamina, 0, MAX_STAMINA);
        slider.value = stamina.ChangeRange(MAX_STAMINA, 1);

        if (stamina == 0 && !isDeath)
        {
            isDeath = true;
            //Respawno nell'ultimo checkpoint
            SettingCamera.Instance().ExitFade();
            Invoke("Respawn", 1f);
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
        stamina = MAX_STAMINA;
        shadow.ResetShadow();
        SettingCamera.Instance().EnterFade();
        isDeath = false;
    }
}
