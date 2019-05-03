using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float scrollSpeed = 1.0f;
    public float tileSizeZ = 10.0f;

    private Vector3 startPosition;

    void Start ()
    {
        startPosition = transform.position;
    }

    void Update ()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}