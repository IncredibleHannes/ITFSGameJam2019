using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiNoteSpawner : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        GameObject newObject = Instantiate(prefab, new Vector3(0, 0, -1), Quaternion.identity) as GameObject;
        newObject.transform.localScale = new Vector3(30, 3, 1);
        Instantiate(prefab, new Vector3(1, -0.3f, -1), Quaternion.identity);
        Instantiate(prefab, new Vector3(2, -1, -1), Quaternion.identity);
        Instantiate(prefab, new Vector3(3, -1.2f, -1), Quaternion.identity);
        Instantiate(prefab, new Vector3(4, -1, -1), Quaternion.identity);
        Instantiate(prefab, new Vector3(5, -1.5f, -1), Quaternion.identity);
        Instantiate(prefab, new Vector3(6, -2, -1), Quaternion.identity);
        GameObject newObject2 = Instantiate(prefab, new Vector3(7, -2.5f, -1), Quaternion.identity) as GameObject;
        newObject2.transform.localScale = new Vector3(30, 3, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
