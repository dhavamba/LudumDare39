using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendGameobject
{
    public static GameObject Instantiate(string name, Transform parent)
    {
        GameObject aux = new GameObject();
        aux.name = "name";
        aux.transform.parent = parent;
        return aux;
    }
}
