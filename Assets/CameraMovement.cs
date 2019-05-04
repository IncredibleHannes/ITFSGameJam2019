using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 startPosition;

    public float xSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dx = xSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(dx, 0.0f, 0.0f);
    }
}
