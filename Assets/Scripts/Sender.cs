using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sender : MonoBehaviour
{
    public delegate void Tak(int i);

    public static event Tak nie;

    // Start is called before the first frame update
    void Start()
    {
        nie(1123);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
