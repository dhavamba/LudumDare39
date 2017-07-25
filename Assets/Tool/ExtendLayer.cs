using UnityEngine;

public static class ExtendLayer
{
    public static LayerMask AddLayer(string layer)
    {
        return AddLayers(new string[] { layer });
    }

    public static LayerMask AddLayers(string[] layers)
    {
        LayerMask mask = 0;
        return AddLayers(layers, mask);
    }

    public static LayerMask AddLayer(string layer, LayerMask mask)
    {
        return AddLayers(new string[] { layer }, mask);
    }

    public static LayerMask AddLayers (string[] layers, LayerMask mask)
    {
        foreach (string s in layers)
        {
            mask |= 1 << LayerMask.NameToLayer(s);
        }
        return mask;
    }

    public static LayerMask RemoveLayers(string[] layers, LayerMask mask)
    {
        foreach (string s in layers)
        {
            mask ^= 1 << LayerMask.NameToLayer(s);
        }
        return mask;
    }

    public static LayerMask RemoveLayer(string layer, LayerMask mask)
    {
        return RemoveLayers(new string[] { layer }, mask);
    }
}
