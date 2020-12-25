using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSetterController : MonoBehaviour
{
    public BlockSet[] blockRow;
    [SerializeField]
    private GameObject player;
    private float x = -1.932f;
    private float y = 4.35f;
    private Vector2 vector;

    void Start()
    {
        int k,l;
        l = 0;
        foreach (BlockSet i in blockRow)
        {
            k = 0;
            foreach (GameObject j in i.blocks)
            {
                vector = new Vector2(x+(k*0.77f),y-(l*0.34f));
                try
                {
                    j.transform.position = vector;
                    Instantiate(j, transform);
                } catch (System.NullReferenceException)
                {
                    k++;
                    continue;
                }
                k++;
            }
            l++;
        }


    }
}

[System.Serializable]
public class BlockSet
{
    public GameObject[] blocks;
}