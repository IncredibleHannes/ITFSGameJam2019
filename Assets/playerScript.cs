using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float ySpeed = 4.0f;
    public float xSpeed = 1.0f;

    private HFTInput m_hftInput;

    // Use this for initialization
    void Start () {
        m_hftInput = GetComponent<HFTInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float dy = ySpeed * (m_hftInput.GetAxis("Horizontal") /* + Input.GetAxis("Vertical")*/) * Time.deltaTime;
        float dx = xSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(dx, dy, 0.0f);
    }
}
