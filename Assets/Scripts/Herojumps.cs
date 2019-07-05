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

    [SerializeField] float bouncedistance = 1;
    IEnumerator tak;
    Vector3 jumpstartpos;
    Vector3 jumpdest;

    Vector3 boardjump;

    Vector3 camoffset;

    Vector3 direction;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {animator = gameObject.GetComponentInChildren<Animator>();
        camoffset = Camera.main.transform.position;
     global = Resources.Load<Globals>("Global");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position,global.point,0.05f);
        if (Input.anyKeyDown)
        {
            if (( !running)&& ( global.point!=transform.position)   )
            {
              jumpstartpos = transform.position;
             //Debug.Log("1");
//            Debug.Log(global.point);
             jumpdest = global.point;
            tak = Korutynka(global.point);
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
    
        direction = jumpstartpos - transform.position;
//        Debug.Log(direction);
            transform.LookAt(jumpdest,Vector3.up);
           // transform.rotation= Quaternion.Euler(0,transform.rotation.y,0);
    
    
    }

    IEnumerator Korutynka(Vector3 target)
    {Vector3 sum = transform.position-target;
        animator.Play("jump",-1);
        running = true;
        float ti = 0;
        timeToReachTarget = sum.magnitude/velocity;
        if (timeToReachTarget!=0)
        {
        animator.SetFloat("speedo",1/timeToReachTarget);    
        }
        
        
        while( sum.magnitude > 0.01)
        {
            startPosition = transform.position;
            sum = transform.position-target;
            //Debug.Log(sum.magnitude);
            
            ti += Time.deltaTime/timeToReachTarget;
            
             transform.position = Vector3.Lerp(startPosition,target, ti);
            
            yield return new WaitForFixedUpdate();
        }
        animator.Play("land",-1);
        running = false;
        
        //yield return null;
        
    }
    
    // ZDEŻENIE Z OBIEKTAMI
    //DODAĆ ANIMACJE UDERZENIA W ŚCIANE
        private void OnTriggerStay(Collider other) {
         
         if (other.tag == "Wall")
         {
             WallCollision();
         }
                
            

        }

        void WallCollision()
        {
//                Debug.Log("kolizja");
            StopCoroutine(tak);
            running = false;
            //transform.position = other.transform.position;
            Vector3 dir = transform.position - jumpstartpos;
            dir = dir.normalized;
            animator.Play("land",-1);
            transform.position -= dir * bouncedistance;
            
        }

    private void OnDrawGizmos() {

        Gizmos.color = Color.black;
        if (global!=null)
        {
        Gizmos.DrawLine(transform.position,direction);                    
        }

    }
}
