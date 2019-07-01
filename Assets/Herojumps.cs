using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herojumps : MonoBehaviour
{
    Globals  global; 
    Vector3 startPosition;
    float t;
    public bool running= false;
    [SerializeField] float timeToReachTarget;
    [SerializeField] float velocity;
    [SerializeField] GameObject board;

    Vector3 boardjump;

    Vector3 camoffset;
    // Start is called before the first frame update
    void Start()
    {
        camoffset = Camera.main.transform.position;
     global = Resources.Load<Globals>("Global");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position,global.point,0.05f);
        if (Input.anyKeyDown)
        {
            if (!running)
            {
             //Debug.Log("1");
            Debug.Log(global.point);
            IEnumerator tak = Korutynka(global.point);
            StartCoroutine(tak);   
            }

        }
        if (!running)
            {
                
                boardjump = Vector3.Lerp(gameObject.transform.position,board.transform.position,0.9f);
                boardjump.y = board.transform.position.y;
                board.transform.position = boardjump;
            }
            Camera.main.transform.position = Vector3.Lerp(gameObject.transform.position + camoffset,Camera.main.transform.position,0.95f);
    }

    IEnumerator Korutynka(Vector3 target)
    {Vector3 sum = transform.position-target;
        running = true;
        float ti = 0;
        timeToReachTarget = sum.magnitude/velocity;
        while( sum.magnitude > 0.01)
        {
            sum = transform.position-target;
            //Debug.Log(sum.magnitude);
            ti += Time.deltaTime/timeToReachTarget;
             transform.position = Vector3.Lerp(startPosition,target, ti);
            yield return new WaitForFixedUpdate();
        }
        running = false;
        startPosition = transform.position;
        //yield return null;
        
    }
    

}
