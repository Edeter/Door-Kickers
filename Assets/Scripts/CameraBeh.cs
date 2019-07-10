using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraBeh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(0,LoadSceneMode.Single);
        }
    }

     public IEnumerator shake(float t)
    {float force=  0.8f;
        Vector3 startpos= transform.position;
     float elapsed = 0;
     while(elapsed < t)
     {
            transform.position = startpos + new Vector3(Random.Range(-force,force),Random.Range(-force,force),0);
        elapsed += Time.deltaTime;
        yield return null;
     }
        transform.position = startpos;
    }
}
