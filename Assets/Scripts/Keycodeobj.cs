using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Key",menuName="key/key")]
public class Keycodeobj : ScriptableObject
{
    public string keycode;
    public string keyname;
    public Vector3 pos;
    public Vector3 scale;
   // public GameObject image;
   private void OnDisable() {
       pos = new Vector3(0,0,0);
   }

}
