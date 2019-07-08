using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybeh : MonoBehaviour
{
    public float health= 4;

 [Header("Particles")]
    public float scalestep=0.1f;
     float upspeed = 0.1f;

 [Header("Shaking")]
    float shakeforce= 0;

    public float shakeadd=0.1f;
    
Vector3 startpos;
    //public GameObject prefabnumer;

    Globals global;
    int cc;

    // Start is called before the first frame update
    void Start()
    {  
        global = Resources.Load<Globals>("Global");
        cc = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        startpos= transform.position;
       for (int i = 0; i < cc; i++)
       {
          transform.GetChild(i).transform.position = startpos + new Vector3(Random.Range(0,shakeforce),Random.Range(0,shakeforce),Random.Range(0,shakeforce));
       }
        
    }

    void tookdmg(int dmg)
    {
        GameObject tak;
        for (int i = 0; i < transform.childCount; i++)
        {
            tak = transform.GetChild(0).gameObject;
            
            if (tak.GetComponent<ParticleSystem>()!= null)
            {
                tak.transform.localScale += new Vector3(scalestep,scalestep,scalestep);
            }
        }
        shakeforce += shakeadd;
        health -=dmg;
        //tak = Instantiate(prefabnumer,transform.position,Quaternion.identity);
        //tak.transform.parent = gameObject.transform;
       // //IEnumerator ie = flyhigh(tak);
       // StartCoroutine(ie); 
        
        StartCoroutine(Camera.main.GetComponent<CameraBeh>().shake());
        if (health < 0)
        {
            StartCoroutine(flyhigh(gameObject));
        }

    }

    
    IEnumerator flyhigh(GameObject go)
    {
        while(true)
        {   upspeed += 0.01f;
            go.transform.position += new Vector3(0,upspeed,0);
            yield return new WaitForEndOfFrame();
        }


    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("111");
        tookdmg(1);

    }
}
