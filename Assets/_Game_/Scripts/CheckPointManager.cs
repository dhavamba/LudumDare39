using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour {

    Transform lastCheckPoint;

    public void setCheckPoint(Transform checkpoint)
    {
        lastCheckPoint = checkpoint;
    }

    public Transform getCheckPoint()
    {
        return lastCheckPoint;
    }
}
