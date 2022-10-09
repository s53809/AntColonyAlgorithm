using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreateNode : MonoBehaviour
{
    [SerializeField]
    private GameObject Map;

    [SerializeField]
    private GameObject NodeObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject ob = Instantiate(NodeObj, mousePos, Quaternion.identity);
            ob.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            ob.transform.parent = Map.transform;
            NodeManagement.Instance.PlusNode(ob);
        }
    }
}
