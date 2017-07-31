using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEventTrigger : MonoBehaviour {

    StaminaController stmController;

    void Start()
    {
        stmController = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        stmController.setStamina(true);
        SettingCamera.Instance().RemoveProfile();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        stmController.setStamina(false);
        SettingCamera.Instance().AddProfile();
    }
}
