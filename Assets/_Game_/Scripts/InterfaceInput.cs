using UnityEngine;
using Rewired;
using System;

//The class is an interface between Rewired and the Game
public class InterfaceInput : Singleton<InterfaceInput>
{
    protected Player player;
    protected bool isJoystick;

    /// <summary>
    /// Return if the player is using the joystick
    /// </summary>
    public bool IsJoystick
    {
        get
        {
            return isJoystick;
        }
    }

    // Use this for initialization
    private void Awake ()
    {
        player = ReInput.players.GetPlayer(0);
    }

    // Use this for the destroy of gameobject
    private new void OnDestroy()
    {
        base.OnDestroy();
    }
}
