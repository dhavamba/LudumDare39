using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAI : MonoBehaviour {

    StaminaController stmController;
    Transform playerPosition;
    Transform myTransform;
    Rigidbody2D rb;
    public float absoluteOffset;
    public float minOffset;
    [Range(0,1)]
    public float speed;

    Vector2 positionToReach;

    void Start()
    {
        stmController = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaController>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myTransform = this.transform;
        rb = GetComponent<Rigidbody2D>();
        positionToReach = myTransform.position;
    }

    void Update()
    {
        //myTransform.Translate(positionToReach * Time.delta);
        float step = speed * Time.deltaTime;
        myTransform.position = Vector3.MoveTowards(myTransform.position, positionToReach, step);
        
        if (stmController.getStamina() < 60)
        {
            RefreshOffset();
            RefreshLocation();
        }
    }

    void RefreshOffset()
    {
        absoluteOffset = stmController.getStamina() / 10;
        if(stmController.getStamina()<=0)
        {
            ResetShadow();
        }

        if(playerPosition.position.x-myTransform.position.x >minOffset)
        {
            ResetShadow();
        }
    }

    void RefreshLocation()
    {
        positionToReach = new Vector2(playerPosition.position.x - absoluteOffset, playerPosition.position.y);
    }

    public void ResetShadow()
    {
        myTransform.position = new Vector2(playerPosition.position.x - minOffset, playerPosition.position.y);
        positionToReach = myTransform.position;
    }
}
