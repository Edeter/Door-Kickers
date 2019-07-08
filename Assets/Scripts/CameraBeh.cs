using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBeh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public IEnumerator shake()
    {float force=  0.8f;
        Vector3 startpos= transform.position;
     float elapsed = 0;
     while(elapsed < 0.1f)
     {
            transform.position = startpos + new Vector3(Random.Range(-force,force),Random.Range(-force,force),0);
        elapsed += Time.deltaTime;
        yield return null;
     }
        transform.position = startpos;
    }
}
