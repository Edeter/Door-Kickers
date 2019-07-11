using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class textchange : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] Sprite on;
[SerializeField] Sprite off;

[SerializeField] float t;
public KeyCode kd;

Globals global;
Color clr;

public Color startcolor;

public GameObject textprefab;

    public Keycodeobj key;
    
    
    private void OnEnable() {
        keyboard.click += change;
    }

    private void OnDisable() {
        keyboard.click -= change;
    }
    
    void Start()
    {
        startcolor = gameObject.GetComponent<SpriteRenderer>().color;
        
        clr = startcolor;
        
        
        
        
        
        GameObject temp =Instantiate(textprefab,transform.position+ new Vector3(-0.4f,0,0.8f),textprefab.transform.rotation);
               temp.GetComponent<TextMesh>().text = key.keyname;
               temp.transform.parent = transform;
        key.pos = transform.position;
        key.scale = transform.localScale;
       
        kd =key.Code;
        global = Resources.Load<Globals>("Global");
       // Debug.Log((int)kd);
    }

    void Update()
    {
        
               key.pos = transform.position;
            if (clr.r<startcolor.r)
            {
                   clr.r += 2 * Time.deltaTime;
            
            }
         if (clr.g<startcolor.g)
            {
                
            clr.g += 2 * Time.deltaTime;
 
            }
            if (clr.b<startcolor.b)
            {

            clr.b += 2 * Time.deltaTime;
            }
           gameObject.GetComponent<SpriteRenderer>().color = clr;
           
        
    }
    void change(int a)
    {
        if (a == (int)kd)
        {
                //Debug.Log("1");
           // gameObject.GetComponent<SpriteRenderer>().color = startcolor;
            clr = Color.black;
            clr.a = startcolor.a;
            
            global.points[key.playernumber] = key.pos;
//            Debug.Log(global.point);
            
            
        }
    }

}
