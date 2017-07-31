using UnityEngine;

public static class ExtendMathf
{
    //vede se due numeri sono simili tramite un fattore di precisione
    public static bool IsSimilar(float a, float b, float precision)
    {
        float difference = Mathf.Abs(a - b);
        return difference < precision;
    }

    public static bool IsInterval(float number, Vector2 range)
    {
        return number >= range.x && number <= range.y;
    }

    public static bool IsInterval(float number, float max)
    {
        return IsInterval(number, new Vector2(0, max));
    }

    public static bool IsSimilar(float a, float b)
    {
        return IsSimilar(a, b, 0.1f);
    }

    public static float ReturnAngleToDir(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle = 360 - Mathf.Abs(angle);
        }
        return angle;
    }

    public static float ChangeRange(this float value, UnityEngine.Vector2 originalRange, UnityEngine.Vector2 newRange)
    {
        float scale = (float)(newRange.y - newRange.x) / (originalRange.y - originalRange.x);
        return (float)(newRange.x + ((value - originalRange.x) * scale));
    }

    public static float ChangeRange(this float value, float maxOld, float maxNew)
    {
        return ChangeRange(value, new Vector2(0, maxOld), new Vector2(0, maxNew));
    }

    public static float AddInCircleRange(this int value, int max)
    {
        return AddInCirlceRange(value, new UnityEngine.Vector2(0, max));
    }

    public static int AddInCirlceRange(this int value, UnityEngine.Vector2 range)
    {
        value++;
        if (value > range.y)
        {
            return (int)range.x;
        }
        return value;
    }
}
