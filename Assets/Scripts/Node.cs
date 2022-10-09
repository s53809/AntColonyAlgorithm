using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjNode
{
    public GameObject AdjObj;
    public Single distance;
    public Single peromon;

    public AdjNode(GameObject AdjObj, Single distance, Single peromon)
    {
        this.AdjObj = AdjObj;
        this.distance = distance;
        this.peromon = peromon;
    }
}

public class Node : MonoBehaviour
{ 
    public List<AdjNode> adjNode = new List<AdjNode>();
    public Int32 N;
}
