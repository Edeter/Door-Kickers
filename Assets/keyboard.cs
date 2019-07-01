using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{

private int[] values;
private bool[] keys;
    public delegate void Board(int p);

    public delegate Vector3 Point();

    public static event Board click;
    

    //public Vector3 point;

    void Awake() {
    values = (int[])System.Enum.GetValues(typeof(KeyCode));
    keys = new bool[values.Length];
}
void Update() {
    for(int i = 0; i < values.Length; i++) {
        keys[i] = Input.GetKeyDown((KeyCode)values[i]);
        if (keys[i])
        {
            click(values[i]);
        }
    }
}
}
