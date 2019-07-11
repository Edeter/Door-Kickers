using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Global",menuName="key/global")]
public class Globals : ScriptableObject
{
    // Start is called before the first frame update
[Header("Globals")]
public Vector3[] points;
public int numberofplayers;

public GameObject[][] Playerkeys;

public KeyCode[][] Playerkeycodes;



private void OnEnable() {
 
    Playerkeys = new GameObject[numberofplayers][];
    for (int i = 0; i < numberofplayers; i++)
    {
        Playerkeys[i] = new GameObject[20];
    }

    Playerkeys[0] = GameObject.FindGameObjectsWithTag("Key 0");
    Playerkeys[1] = GameObject.FindGameObjectsWithTag("Key 1");

Playerkeycodes = new KeyCode[numberofplayers][];
    for (int i = 0; i < numberofplayers; i++)
    {
        Playerkeycodes[i] = new KeyCode[20];
    }
    for (int i = 0; i < numberofplayers; i++)
    {
        for (int j = 0; j < 20; j++)
        {
            Playerkeycodes[i][j] =  Playerkeys[i][j].GetComponent<textchange>().key.Code;
        }
    }

    points = new Vector3[numberofplayers];

    for (int i = 0; i < points.Length; i++)
    {
        points[i] = new Vector3(0,0,0);
    }

}

}
