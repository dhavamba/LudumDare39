using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendRigidBody2D
{
    public static float precision = 0.1f;

    public static bool IsMovement(this Rigidbody2D value, Vector2 dir, bool fly)
    {
        if (!fly && dir != Vector2.zero)
        {
            Vector2 newPosition = ExtendVector2.CalcolateVectorWithAngleInSquare(value.position, dir, value.GetComponent<BoxCollider2D>().size, value.transform.localScale);
            newPosition += dir.normalized * precision;
            Collider2D[] colliders = Physics2D.OverlapPointAll(newPosition);
            colliders = Array.FindAll(colliders, x => x.gameObject.tag == "Floor");
            return colliders.Length > 0;
        }
        else
        {
            return true;
        }
    }
}
