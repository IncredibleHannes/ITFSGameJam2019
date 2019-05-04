using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    public float xSpeed = 5.0f;
    private Transform cam;
    void Start()
    {
        cam = Camera.main.transform;

    }

    void Update()
    {
        float dx = xSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(dx, 0.0f, 0.0f);


    }
}