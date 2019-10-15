using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Transform[] targetsAB;

    void Start()
    {
        targetsAB = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            targetsAB[i] = transform.GetChild(i);
        }
    }
}