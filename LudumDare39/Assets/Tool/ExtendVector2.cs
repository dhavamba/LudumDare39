using UnityEngine;

public static class ExtendVector2
{

	// Use this for initialization
	public static Vector2 Abs (Vector2 vector)
    {
        return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
	}

    public static bool IsInterval(Vector2 intern, Vector2 rangeX, Vector2 rangeY)
    {
        return intern.x >= rangeX.x && intern.x <= rangeX.y && intern.y >= rangeY.x && intern.y <= rangeY.y;
    }


    public static bool IsInterval(Vector2 intern, Vector2 range)
    {
        return IsInterval(intern, new Vector2(0, range.x), new Vector2(0, range.y));
    }

    public static Vector2 PointDot(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x * b.x, a.y * b.y);
    }

    public static Vector2 PointDot(Vector2 a, Vector2 b, Vector2 c)
    {
        return new Vector2(a.x * b.x * c.x, a.y * b.y * c.x);
    }

    public static Vector2 CalcolateVectorWithAngleInSquare(Vector2 center, Vector2 v, Vector2 sizeCollider, Vector2 sizeTransform)
    {
        float angle = ExtendMathf.ReturnAngleToDir(v);
        float distance = 0;
        float newAngle = 0;
        Vector2 aux = Vector2.zero;

        if (angle >= 0 && angle <= 45)
        {
            newAngle = angle - 0;
            distance = Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(1, distance);
        }
        else if (angle >= 45 && angle <= 90)
        {
            newAngle = angle - 45;
            distance = 1 - Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(distance, 1);
        }
        else if (angle >= 90 && angle <= 135)
        {
            newAngle = angle - 90;
            distance = Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(-distance, 1);
        }
        else if (angle >= 135 && angle <= 180)
        {
            newAngle = angle - 135;
            distance = 1 - Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(-1, distance);
        }
        else if (angle >= 180 && angle <= 225)
        {
            newAngle = angle - 180;
            distance = Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(-1, -distance);
        }
        else if (angle >= 225 && angle <= 270)
        {
            newAngle = angle - 225;
            distance = 1 - Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(-distance, -1);
        }
        else if (angle >= 270 && angle <= 315)
        {
            newAngle = angle - 270;
            distance = Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(distance, -1);
        }
        else if (angle >= 315)
        {
            newAngle = angle - 315;
            distance = 1 - Mathf.Tan(newAngle * Mathf.Deg2Rad);
            aux = new Vector2(1, -distance);
        }

        aux = center + PointDot(aux, sizeTransform, sizeCollider * 0.5f);
        return aux;
    }

}
