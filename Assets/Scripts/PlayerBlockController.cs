using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBlockController : BoxController
{
    Collider2D fourDirection = new Collider2D();
    public bool movable = true;
    private GameObject coolDownTime;
    private void Start()
    {
        coolDownTime = GameObject.Find("CoolDownTime");
    }
    public void move(int direction)
    {
        //0 up, 1 down, 2 left, 3 right
        FourDirections fourDirections = (FourDirections) direction;
        if (movable)
        {
            actionByKey(getDirectionPoint(fourDirections));
            StartCoroutine(DelayProcess(3.0f));
        }
    }

    private void changePos(ref Collider2D object1)
    {
        Vector2 vector = object1.transform.position;
        object1.transform.position = gameObject.transform.position;
        gameObject.transform.position = vector;
    }

    private Vector2 getDirectionPoint(FourDirections fourDirections)
    {
        switch (fourDirections)
        {
            case FourDirections.Up:
                return new Vector2(transform.position.x, transform.position.y + 0.3f);
            case FourDirections.Down:
                return new Vector2(transform.position.x, transform.position.y - 0.3f);
            case FourDirections.Left:
                return new Vector2(transform.position.x - 0.7f, transform.position.y);
            case FourDirections.Right:
                return new Vector2(transform.position.x + 0.7f, transform.position.y);
        }
        Debug.LogError("not in Enum");
        return new Vector2();
    }

    private void actionByKey(Vector2 vector2)
    {
        try
        {
            fourDirection = Physics2D.OverlapPoint(vector2);
            if (fourDirection.GetComponent<BoxController>())
            {
                changePos(ref fourDirection);
            }
        } catch (System.NullReferenceException e)
        {
            return;
        }
    }
    IEnumerator DelayProcess(float wait)
    {
        float alpha = wait;
        while (alpha >= 0)
        {
            movable = false;
            coolDownTime.GetComponent<Text>().text = "Cool Down Time :"+(int)alpha;
            alpha -= Time.deltaTime;
            // 残り時間が0以上の場合はタイマーを更新　
            yield return null;
        }
        movable = true;
        coolDownTime.GetComponent<Text>().text = "Movable";
        Debug.Log("end");
    }
}
