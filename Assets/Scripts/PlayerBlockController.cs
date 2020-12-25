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
                    changePos(ref fourDirection);
                }
                return;
            case FourDirections.Down:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y - 0.3f));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    changePos(ref fourDirection);
                }
                return;
            case FourDirections.Left:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x - 0.7f, transform.position.y));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    changePos(ref fourDirection);
                }
                return;
            case FourDirections.Right:
                fourDirection = Physics2D.OverlapPoint(new Vector2(transform.position.x + 0.7f, transform.position.y));
                Debug.Log(fourDirection.transform.gameObject.name);
                if (fourDirection.GetComponent<BoxController>())
                {
                    changePos(ref fourDirection);
                }
                return;
        }
    }

    private void changePos(ref Collider2D object1)
    {
        Vector2 vector = object1.transform.position;
        object1.transform.position = gameObject.transform.position;
        gameObject.transform.position = vector;
    }
}
