using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEventTrigger : MonoBehaviour {

    StaminaController stmController;
    public bool isRescueZone = false;

    void Start()
    {
        stmController = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !isRescueZone)
        {
            stmController.setStamina(true);
        }
        else if (other.CompareTag("Player") && isRescueZone)
        {
            stmController.setStamina(false);
        }
    }
}
