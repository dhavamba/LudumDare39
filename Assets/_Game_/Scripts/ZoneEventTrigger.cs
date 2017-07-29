using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEventTrigger : MonoBehaviour {

    public StaminaController stmController;
    public bool isRescueZone = false;

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
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isRescueZone)
        {
            stmController.setStamina(false);
        }
        else if (other.CompareTag("Player") && isRescueZone)
        {
            stmController.setStamina(false);
        }
    }
}
