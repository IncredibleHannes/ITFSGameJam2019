﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidiNote : MonoBehaviour
{
    public float scrollSpeed = 2.0f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}