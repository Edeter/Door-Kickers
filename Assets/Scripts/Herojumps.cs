using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Herojumps : MonoBehaviour
{
    Globals  global; 
    Vector3 startPosition;
    float t;
    public bool running= false;
    [SerializeField] float timeToReachTarget;
    [SerializeField] float velocity;
    [SerializeField] GameObject board;

    

 [Header("Wall collison")]
    [SerializeField] float bouncedistance = 1;

    [Header("Trail")]

    [SerializeField] GameObject trailprefab;
    [SerializeField] float traildecay = 1;
    [SerializeField] float traildelay = 0.1f;

    [Header("Slider")]
    [SerializeField] Slider slider;
    [SerializeField] float sliderdecay;
    public float newsliderdecay;
    IEnumerator tak;
    Vector3 jumpstartpos;
    Vector3 jumpdest;

    Vector3 boardjump;

    Vector3 camoffset;

    Vector3 direction;

    Animator animator;
    float passedtime = 0;
    // Start is called before the first frame update
    void Start()
    {animator = gameObject.GetComponentInChildren<Animator>();
        camoffset = Camera.main.transform.position;
     global = Resources.Load<Globals>("Global");
     newsliderdecay = sliderdecay;
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
                //Transforming keyboard after jumping

                boardjump = Vector3.Lerp(gameObject.transform.position,board.transform.position,0.9f);
                boardjump.y = board.transform.position.y;
                board.transform.position = boardjump;
               
            }
            if (running && passedtime > traildelay)
            {
                //Trail

                 GameObject temp = Instantiate(trailprefab,transform.position,transform.rotation);
                 temp.transform.Rotate(new Vector3(0,90,0),Space.World);
                Destroy(temp,traildecay);
                passedtime = 0;
            }
            Camera.main.transform.position = Vector3.Lerp(gameObject.transform.position + camoffset,Camera.main.transform.position,0.95f);
        passedtime += Time.deltaTime;
        direction = jumpstartpos - transform.position;
//        Debug.Log(direction);
            transform.LookAt(jumpdest,Vector3.up);
           // transform.rotation= Quaternion.Euler(0,transform.rotation.y,0);
    
        slider.value -= newsliderdecay;
        
        if (newsliderdecay <0.6)
        {
            newsliderdecay += newsliderdecay/30;
        }

    
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
         
         //if (other.tag == "Wall")
         //{
             WallCollision();
         //}

         slider.value = slider.maxValue;
         newsliderdecay = sliderdecay;
                
                if (other.tag=="Enemy")
                {
                    StartCoroutine(other.gameObject.GetComponent<Enemybeh>().kicked(global.point));
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
       // Gizmos.DrawLine(transform.position,direction);                    
        }

    }
}
