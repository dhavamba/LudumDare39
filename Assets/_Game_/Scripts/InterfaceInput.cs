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


        ReInput.ControllerConnectedEvent += OnControllerEvent;
        ReInput.ControllerDisconnectedEvent += OnControllerEvent;

        OnControllerEvent(null);
    }

    // Use this for the destroy of gameobject
    private new void OnDestroy()
    {
        base.OnDestroy();
        ReInput.ControllerConnectedEvent -= OnControllerEvent;
        ReInput.ControllerDisconnectedEvent -= OnControllerEvent;
    }

    //Method that manages the controller when attached and detached
    private void OnControllerEvent(ControllerStatusChangedEventArgs args)
    {
        int count1 = player.controllers.Joysticks.Count;
        isJoystick = Convert.ToBoolean(count1);

        //Enable or disable joystick / keybards
        player.controllers.maps.SetAllMapsEnabled(!isJoystick, ControllerType.Keyboard);
        player.controllers.maps.SetAllMapsEnabled(isJoystick, ControllerType.Joystick);
    }

}
