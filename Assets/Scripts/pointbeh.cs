using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointbeh : MonoBehaviour
{
    Globals global;
    // Start is called before the first frame update
    void Start()
    {
        global = Resources.Load<Globals>("Global");
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = global.point;
    }
}
