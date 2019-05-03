using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float ySpeed = 4.0f;
    public float xSpeed = 1.0f;

    private HFTInput m_hftInput;
    private HFTGamepad m_gamepad;
    private TrailRenderer tr;

    // Use this for initialization
    void Start()
    {
        m_hftInput = GetComponent<HFTInput>();
        m_gamepad = GetComponent<HFTGamepad>();

        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = m_gamepad.color;

        tr = GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(m_gamepad.color, 0.0f), new GradientColorKey(m_gamepad.color, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        tr.colorGradient = gradient;
    }

    // Update is called once per frame
    void Update()
    {
        float dy = ySpeed * (m_hftInput.GetAxis("Horizontal") /* + Input.GetAxis("Vertical")*/) * Time.deltaTime;
        float dx = xSpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(dx, dy, 0.0f);

        if (transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }

        if (m_hftInput.GetButtonDown("fire1") || Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().AddForce((new Vector2(0, 200)));
        }
    }
}
