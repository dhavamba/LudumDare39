using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    bool isOpen;

	public void Use()
    {
        if(isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
        isOpen = !isOpen;
    }

    public void Open()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 3);
        Debug.Log("Apro porta");
    }

    public void Close()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 3);
        Debug.Log("Chiudo porta");
    }
}
