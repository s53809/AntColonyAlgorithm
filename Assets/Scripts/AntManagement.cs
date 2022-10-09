using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject Ant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ob = Instantiate(Ant);
            ob.GetComponent<AntSelect>().curNode = NodeManagement.Instance.SelectRandomNode();
        }
    }
}
