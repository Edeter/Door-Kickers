using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointing : MonoBehaviour
{

    RaycastHit hit;
    Vector3 point;
    [SerializeField] LayerMask layerMask;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray,out hit, Mathf.Infinity, layerMask))
        {
            point = hit.point;
        }
       // Debug.Log(point);

    
    }
    private void OnGUI() {
        GUI.color = Color.black;
     //   GUI.Label(new Rect(10,10,100,50),point.ToString());
    }
}
