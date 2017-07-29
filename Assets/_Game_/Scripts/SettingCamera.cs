using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class SettingCamera : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        ProCamera2D cam = GetComponent<ProCamera2D>();
        Transform pl = GameObject.FindGameObjectWithTag("Player").transform;

        cam.AddCameraTarget(pl);
	}

}
