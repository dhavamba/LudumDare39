using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

    Transform lastCheckPoint;
    public Transform initialCheckPoint;

    public void Start()
    {
        lastCheckPoint = initialCheckPoint;
    }

    public void setCheckPoint(Transform checkpoint)
    {
        if(checkpoint.position.x>lastCheckPoint.position.x)
            lastCheckPoint = checkpoint;
    }

    public Transform getCheckPoint()
    {
        return lastCheckPoint;
    }
}
