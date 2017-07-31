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
        Dialogues.Instance().AddDialogue();
        GameObject.FindGameObjectWithTag("Shadow").GetComponent<AudioSource>().Stop();
        SettingCamera.Instance().RemoveProfile();
        GameObject.FindGameObjectWithTag("Shadow").GetComponent<AudioSource>().Play();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        stmController.setStamina(false);
        Dialogues.Instance().Stop();
        SettingCamera.Instance().AddProfile();
    }
}
