﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public Animator animator;
    public GameObject groundCheck;

    bool facingRight = true;

    public bool napped = false;

    public bool enteredRoom;
    public float cameraSize;

    public bool trappedSequence = false;
    public bool trappedSequencePhase2 = false;
    public Vector3 currentPos;
    public Vector3 newPos;
    public Vector3 originalCameraPos;

    public bool finalBoss = false;

    float moveDirection = 0;
    public bool isGrounded = false;
    public bool isFollowingRoom = false;
    public bool isInLargeRoom = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    Collider2D mainCollider;
    AudioSource step;
    // Check every collider except Player and Ignore Raycast
    LayerMask layerMask = ~(1 << 2 | 1 << 9);
    Transform t;
    // Use this for initialization
    void Start()
    {
        groundCheck = GameObject.Find("groundCheck");
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<Collider2D>();
        step = GetComponent<AudioSource>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
            cameraPos = mainCamera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!napped && !trappedSequence)
        {
            animator.enabled = true;
            // Change facing direction
            if (moveDirection != 0)
            {
                animator.SetBool("isRun", true);
                step.loop = true;
                step.enabled = true;
                if (moveDirection > 0 && !facingRight)
                {
                    facingRight = true;
                    t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                }
                if (moveDirection < 0 && facingRight)
                {
                    facingRight = false;
                    t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
                }
            }
            else
            {
                animator.SetBool("isRun", false);
                step.loop = false;
                step.enabled = false;
            }
        }
        // Examine the Room Sequence
        if(trappedSequence)
        {
            moveDirection = 0;
            currentPos = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
            animator.SetBool("isRun", false);
            animator.enabled = false;
            step.loop = false;
            step.enabled = false;
            r2d.gravityScale = 0f;

            if (trappedSequencePhase2)
            {
                mainCamera.transform.position = Vector3.Lerp(currentPos, new Vector3(t.position.x, originalCameraPos.y, originalCameraPos.z), Time.deltaTime * 4f);
                if (facingRight)
                    if (newPos.x < t.position.x)
                    {
                        if (mainCamera.transform.position.x >= t.position.x - 0.05)
                        {
                            trappedSequence = false;
                            trappedSequencePhase2 = false;
                        }
                    }
                    else
                    {
                        if (mainCamera.transform.position.x <= t.position.x + 0.05)
                        {
                            trappedSequence = false;
                            trappedSequencePhase2 = false;
                        }
                    }
                else
                    if (newPos.x < t.position.x)
                    {
                        if (mainCamera.transform.position.x >= t.position.x - 0.05)
                        {
                            trappedSequence = false;
                            trappedSequencePhase2 = false;
                        }
                    }
                    else
                    {
                        if (mainCamera.transform.position.x <= t.position.x + 0.05)
                        {
                            trappedSequence = false;
                            trappedSequencePhase2 = false;
                        }
                    }
            }
            else
                mainCamera.transform.position = Vector3.Lerp(currentPos, newPos, Time.deltaTime * 2f);

            if (facingRight)
                if (newPos.x < t.position.x)
                {
                    if (mainCamera.transform.position.x <= newPos.x + 0.1)
                        trappedSequencePhase2 = true;
                }
                else
                {
                    if (mainCamera.transform.position.x >= newPos.x - 0.1)
                        trappedSequencePhase2 = true;
                }
            else
                if (newPos.x < t.position.x)
                {
                    if (mainCamera.transform.position.x <= newPos.x + 0.1)
                        trappedSequencePhase2 = true;
                }
                else
                {
                    if (mainCamera.transform.position.x >= newPos.x - 0.1)
                        trappedSequencePhase2 = true;
                }
        }
        else
        {
            if (isFollowingRoom)
            {
                mainCamera.transform.position = new Vector3(t.position.x, t.position.y + 10f, cameraPos.z);
                cameraPos = mainCamera.transform.position;
            }
            else if (isInLargeRoom)
            {
                mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
                cameraPos = mainCamera.transform.position;
            }
            else
            {
                mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
                cameraPos = mainCamera.transform.position;
            }
        }

        if(enteredRoom)
        {
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, cameraSize, Time.deltaTime * 4);
        }
        if (mainCamera.orthographicSize <= cameraSize - 1 && mainCamera.orthographicSize >= cameraSize + 1)
            enteredRoom = false;

    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);
        // Check if player is grounded
        //isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);

        isGrounded = groundCheck.GetComponent<groundCheck>().getGroundCheck();
        if (!napped && !trappedSequence)
        {
            r2d.gravityScale = gravityScale;
            // Movement controls
            if (Input.GetKey(KeyCode.A))
                moveDirection = -1;
            else if (Input.GetKey(KeyCode.D))
                moveDirection = 1;
            else
                moveDirection = 0;

            // Jumping
            if (Input.GetKey(KeyCode.Space) && isGrounded)
                r2d.velocity = Vector2.up * jumpHeight;

            // Apply movement velocity
            r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
        }
        else
            r2d.velocity = new Vector2(0f, 0f);
    }
}
