using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockController : BoxController
{
    Collider2D fourDirection = new Collider2D();

    public void move(int direction)
    {
        //0 up, 1 down, 2 left, 3 right
        FourDirections fourDirections = (FourDirections) direction;
        switch (fourDirections)
        {
            case FourDirections.Up:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x,transform.position.y+0.3f));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    Debug.Log("Up");
                }
                return;
            case FourDirections.Down:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y - 0.3f));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    Debug.Log("Down");
                }
                return;
            case FourDirections.Left:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x - 0.7f, transform.position.y));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    Debug.Log("Left");
                }
                return;
            case FourDirections.Right:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x + 0.7f, transform.position.y));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    Debug.Log("Right");
                }
                return;
        }
    }
}
