using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sender.nie += display;
    }

    void display(int a)
    {
        Debug.Log(a);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
