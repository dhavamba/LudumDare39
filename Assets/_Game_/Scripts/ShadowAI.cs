using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ShadowAI : MonoBehaviour {

    StaminaController stmController;
    Transform playerPosition;
    Transform myTransform;
    Rigidbody2D rb;
    public float absoluteOffset;
    public float minOffset;
    [Range(0,1)]
    public float speed;

    public AudioClip[] voices;
    public AudioClip violin;

    public AudioSource aSrcVoice, aSrcViolin;

    public float timer;

    Vector2 positionToReach;

    void Start()
    {
        aSrcVoice = GetComponent<AudioSource>();
        aSrcViolin = transform.Find("Violino").gameObject.GetComponent<AudioSource>();
        stmController = GameObject.FindGameObjectWithTag("Player").GetComponent<StaminaController>();
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myTransform = this.transform;
        rb = GetComponent<Rigidbody2D>();
        positionToReach = myTransform.position;
        timer = 2f;
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

        if(stmController.getStamina() < 10)
        {
            if (!aSrcViolin.isPlaying)
            {
                aSrcViolin.clip = violin;
                aSrcViolin.Play();
            }
        }
        else
        {
            aSrcViolin.Stop();
        }
         
        if (!aSrcVoice.isPlaying)
        { 
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                int x = Random.Range(0, 4);
                aSrcVoice.clip = voices[x];
                aSrcVoice.Play();
                timer = Random.Range(0, 11);
            }
        }

    }

    void RefreshOffset()
    {
        absoluteOffset = stmController.getStamina() / 10;
        if(stmController.getStamina()<=0)
        {
            ResetShadow();
        }

        /*if(playerPosition.position.x - myTransform.position.x > minOffset)
        {
            ResetShadow();
        }*/
    }

    void RefreshLocation()
    {
        positionToReach = new Vector2(playerPosition.position.x - absoluteOffset, playerPosition.position.y);
    }

    public void ResetShadow()
    {
        positionToReach = new Vector2(playerPosition.position.x - 10, playerPosition.position.y);
        
    }
}
