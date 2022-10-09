using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManagement : MonoBehaviour
{
    private static NodeManagement instance;
    public static NodeManagement Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NodeManagement();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private List<GameObject> nodes = new List<GameObject>();
    public Int32 nodeCount = 0;
    
    public void PlusNode(GameObject obj)
    {
        foreach(GameObject node in nodes)
        {
            Single distance = Vector3.Distance(node.transform.position, obj.transform.position);
            node.GetComponent<Node>().adjNode.Add(new AdjNode(obj, distance, 1));
            obj.GetComponent<Node>().adjNode.Add(new AdjNode(node, distance, 1));
        }
        obj.GetComponent<Node>().N = nodeCount++;
        nodes.Add(obj);
    }

    public GameObject SelectRandomNode()
    {
        if(nodeCount == 0)
        {
            return null;
        }
        return nodes[UnityEngine.Random.Range(0, nodeCount)];
    }
}
