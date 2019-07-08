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
Vector3 clr =new Vector3 (255,255,255);

public GameObject textprefab;

    [SerializeField] Keycodeobj key;
    
    
    private void OnEnable() {
        keyboard.click += change;
    }

    private void OnDisable() {
        keyboard.click -= change;
    }
    
    void Start()
    {
        GameObject temp =Instantiate(textprefab,transform.position+ new Vector3(-0.4f,0,0.8f),textprefab.transform.rotation);
               temp.GetComponent<TextMesh>().text = key.keyname;
               temp.transform.parent = transform;
        key.pos = transform.position;
        key.scale = transform.localScale;
       
        kd =(KeyCode)System.Enum.Parse(typeof(KeyCode),key.keycode);
        global = Resources.Load<Globals>("Global");
       // Debug.Log((int)kd);
    }

    void Update()
    {
        
               key.pos = transform.position;
            if (clr.x<255)
            {
                   clr.x += 2 * Time.deltaTime;
            clr.y += 2 * Time.deltaTime;
            clr.z += 2 * Time.deltaTime;
            }
         
           gameObject.GetComponent<SpriteRenderer>().color = new Color(clr.x,clr.y,clr.z,.3f);
           
        
    }
    void change(int a)
    {
        if (a == (int)kd)
        {
            //Debug.Log("1");
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,.6f);
            clr = new Vector3(0,0,0);
            
            global.point = key.pos;
//            Debug.Log(global.point);
        }
    }

}
