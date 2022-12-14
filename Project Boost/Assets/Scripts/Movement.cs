using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float boost = 5f;
    bool isAPressed;
    bool isDPressed;
    bool isSpacePressed;
    float inputHorizontal;
    [SerializeField] float rotation = 5f;
    [SerializeField] float maxSpeed = 10f;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        ProcessInput();
    }

    private void FixedUpdate()
    {
        MoveRocket();
    }

    private void ProcessInput()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        isAPressed = Input.GetKey("a");
        isDPressed = Input.GetKey("d");
        isSpacePressed = Input.GetKey("space");
    }

    private void MoveRocket()
    {
        if (isSpacePressed)
        {
            rb.AddRelativeForce(new Vector3(0, boost, 0) * Time.fixedDeltaTime);
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            }
            if (!audioSource.isPlaying)
            { 
                audioSource.Play();
            }
        }
        else
        {

            audioSource.Stop();
        }
        if (isAPressed || isDPressed)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(new Vector3(0, 0, (-1f * inputHorizontal * rotation * Time.fixedDeltaTime))));
        }
    }
}
