﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float ySpeed = 4.0f;
    private float xSpeed = 10.0f;

    public float jumpSpeed = 10;
    public float glideForce = 7;

    private HFTInput m_hftInput;

    private int jumps;

    private int MAX_JUMPS = 2;

    private HFTGamepad m_gamepad;
    private TrailRenderer tr;
    private Transform cam;

    private ScoreScript scoreScript;

    private static int playerNo = 0;

    public ParticleSystem[] noteParticles = new ParticleSystem[] { };

    public Rigidbody2D rigidbody2d;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main.transform;
        m_hftInput = GetComponent<HFTInput>();
        m_gamepad = GetComponent<HFTGamepad>();

        // set player colors
        // Debug.Log("setting color for player %i", playerNo);
        Color[] colors = { Color.red, Color.green, Color.blue };
        Color thisColor = colors[playerNo % 3];
        playerNo++;

        m_gamepad.Color = thisColor;

        foreach (var particle in noteParticles)
        {
            ParticleSystem.MainModule main = particle.main;
            main.startColor = thisColor;
        }

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = thisColor;

        tr = GetComponent<TrailRenderer>();
        tr.material = new Material(Shader.Find("Sprites/Default"));

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(thisColor, 0.0f), new GradientColorKey(thisColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        tr.colorGradient = gradient;

        GameObject playerManager = GameObject.FindGameObjectWithTag("Player");
        scoreScript = playerManager.GetComponent<ScoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z);

        if (transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
            rigidbody2d.velocity = new Vector2(0, 0);

            scoreScript.Miss();
        }

        if ((m_hftInput.GetButtonDown("fire1") || Input.GetKeyDown("space")) && jumps > 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpSpeed);
            jumps--;
        }

        if (rigidbody2d.velocity.y != 0 && (m_hftInput.GetButton("fire2") || Input.GetKey("b")))
        {
            rigidbody2d.AddForce((new Vector2(0, glideForce)));
        }

        if (rigidbody2d.velocity.y == 0)
        {
            animator.Play("Walking");
        }
        else
        {
            animator.Play("Jumping");
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var normal = col.contacts[0].normal;
        if (normal.y > 0)
        { //if the bottom side hit something 
            Debug.Log("You Hit the floor");
            jumps = MAX_JUMPS;

            scoreScript.Hit();
        }
        if (normal.y < 0)
        { //if the top side hit something
            Debug.Log("You Hit the roof");
        }
    }
}
