using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MidiNote : MonoBehaviour
{
    public float length = 1;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        transform.localScale = new Vector3(this.length, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
