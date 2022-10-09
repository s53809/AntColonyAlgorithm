using UnityEngine;
using System.Collections;

public class LineCreate : MonoBehaviour
{
    private static LineCreate instance;

    public static LineCreate Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LineCreate();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }

    private LineRenderer line;
    private Vector3 startPos;
    private Vector3 endPos;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);
    }
    // Following method creates line runtime using Line Renderer component
    private void createLine()
    {
        line = new GameObject("Line").AddComponent<LineRenderer>();
        line.material = new Material(Shader.Find("Diffuse"));
        line.SetVertexCount(2);
        line.SetWidth(0.1f, 0.1f);
        line.SetColors(Color.white, Color.white);
        line.useWorldSpace = true;
    }
    // Following method adds collider to created line
    private void addColliderToLine()
    {
        BoxCollider col = new GameObject("Collider").AddComponent<BoxCollider>();
        col.transform.parent = line.transform; //Collider is added as child object of line
        float lineLength = Vector3.Distance(startPos, endPos); //length of line
        // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
        col.size = new Vector3(lineLength, 0.1f, 1f);
        Vector3 midPoint = (startPos + endPos) / 2;
        col.transform.position = midPoint; // setting position of collider object
        // Following lines calculate the angle between start Pos and endPos
        float angle = (Mathf.Abs(startPos.y - endPos.y) / Mathf.Abs(startPos.x - endPos.x));
        if ((startPos.y < endPos.y && startPos.x > endPos.x) || (endPos.y < startPos.y && endPos.x > startPos.x))
        {
            angle *= -1;
        }

        if (angle != angle) // check NaN        
        {
            Destroy(line.gameObject); // NaN? Destroy gameObject
        }
        else // Not NaN
        {
            angle = Mathf.Rad2Deg * Mathf.Atan(angle);
            col.transform.Rotate(0, 0, angle);
        }
    }
}