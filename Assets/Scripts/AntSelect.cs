using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSelect : MonoBehaviour
{
    public GameObject curNode;
    private Stack<GameObject> nodeHistory = new Stack<GameObject>();
    private List<Boolean> visited = new List<Boolean>();
    public Single dstPower = 10;
    public Single pheromonePower = 1;
    void Start()
    {
        nodeHistory.Push(curNode);
        for(Int32 i = 0; i < NodeManagement.Instance.nodeCount; i++)
        {
            visited.Add(false);
        }
        visited[curNode.GetComponent<Node>().N] = true;

        transform.position = curNode.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FindNextObj();
        }
    }

    public void FindNextObj()
    {
        Boolean CantGo = true;
        var wrPicker = new Rito.WeightedRandomPicker<GameObject>();
        foreach (AdjNode adj in curNode.GetComponent<Node>().adjNode){
            if (!visited[adj.AdjObj.GetComponent<Node>().N])
            {
                CantGo = false;
                Single desirability = (1 / adj.distance * dstPower) * (adj.peromon * pheromonePower);
                wrPicker.Add(adj.AdjObj, desirability);
                Debug.Log(adj.AdjObj.GetComponent<Node>().N.ToString() + " " + desirability.ToString());
            }
        }
        if (CantGo) { Debug.Log("All of Node are visited"); return; }
        GameObject nextObj = wrPicker.GetRandomPick();
        visited[nextObj.GetComponent<Node>().N] = true;
        nodeHistory.Push(nextObj);
        curNode = nextObj;

        transform.position = curNode.transform.position;
    }
}
