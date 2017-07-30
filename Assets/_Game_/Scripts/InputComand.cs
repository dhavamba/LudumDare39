using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;
using Rewired;

//The class has methods that use for abstracting the input manager
public class InputComand : InterfaceInput
{

    /// <summary>
    /// Return the values of movement axis
    /// </summary>
    public float Movement()
    {
        return player.GetAxis("Horizontal");
    }

    public bool Jump()
    {
        return player.GetButtonDown("Jump");
    }

    public bool Use()
    {
        return player.GetButtonDown("Use");
    }

    public bool Enter()
    {
        return player.GetButtonDown("Enter");
    }

    public bool Return()
    {
        return player.GetButtonDown("Under");
    }
}
