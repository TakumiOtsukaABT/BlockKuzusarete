using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        var b = randomMultipleRange(20,70,110,160,200,250,290,340);
        var a = DegreeToVector2(b);
        var force = (a) * speed;
        GetComponent<Rigidbody2D>().AddForce(force);
        Debug.Log(a);
        Debug.Log(b);
    }

    private static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
    private static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
    private static float randomMultipleRange(float min1,float max1, float min2, float max2, float min3, float max3, float min4, float max4)
    {
        while (true)
        {
            float random = Random.Range(min1, max3);
            if (random > min1 && random < max1)
            {
                return random;
            }
            if (random > min2 && random < max2)
            {
                return random;
            }
            if (random > min3 && random < max3)
            {
                return random;
            }
            if (random > min4 && random < max4)
            {
                return random;
            }
        }
    }
}
