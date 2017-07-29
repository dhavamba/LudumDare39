using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour {

    private float useSpeed;

    [Range(0,5)]
    [SerializeField]
    private float directionSpeed;
    float origY,origX;
    [Range(0, 10)]
    [SerializeField]
    private float distance = 10.0f;

    [SerializeField]
    bool H_V;

	// Use this for initialization
	void Start () {

        if (!H_V)
        {
            origY = transform.position.y;
            useSpeed = -directionSpeed;
        }
        else
        {
            origX = transform.position.x;
            useSpeed = -directionSpeed;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (!H_V)
        {
            if (origY - transform.position.y > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origY - transform.position.y < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(0, useSpeed * Time.deltaTime, 0);
        }
        else
        {
            if (origX - transform.position.x > distance)
            {
                useSpeed = directionSpeed; //flip direction
            }
            else if (origX - transform.position.x < -distance)
            {
                useSpeed = -directionSpeed; //flip direction
            }
            transform.Translate(useSpeed * Time.deltaTime,0, 0);
        }
    }
}
