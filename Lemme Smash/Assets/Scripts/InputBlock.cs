﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : MonoBehaviour
{
    [Header("Input Fields")]

    [SerializeField]
    private KeyCode keyCode;

    [SerializeField]
    private string buttonName;

    [SerializeField]
    private string axisName;

    // Used to make the trigger buttons act like buttons
    private bool axisInUse;

    private bool canHit;
    private bool hit;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public Animator animator;

    public Action ValidHitCallback
    {
        get; set;
    }

    public Action MissCallback
    {
        get; set;
    }

    // Start is called before the first frame update
    void Awake()
    {
        axisInUse = hit = canHit = false;

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("isAHit", 0);
        animator.SetInteger("isInputting", 0);

        // Handle all kinds of input
        if (GetButtonDown() || (!axisInUse && GetAxis() > 0) || Input.GetKeyDown(keyCode))
        {
            Debug.Log($"{axisName}: {GetAxis()}");

            animator.SetInteger("isInputting", 1);

            if (canHit)
            {
                //Debug.Log("HIT!");
                ValidHitCallback();

                animator.SetInteger("isAHit", 1); //Tells the animator is a hit and not a miss for the animation

                // Replace this with better animation
                spriteRenderer.color = new Color(255f, 255f, 0f, 255f);

                canHit = false;
                hit = true;
            }
            else
            {
                MissCallback();
            }
        }

        // Reset the trigger button if not pressed
        if (GetAxis() == 0)
        {
            axisInUse = false;
        }
    }

    // Prevents errors when an input axis is not assigned
    private float GetAxis()
    {
        if (!(axisName is null))
        {
            if (axisName.Length > 0)
            {
                // prevent "press and hold"
                axisInUse = true;
                return Input.GetAxisRaw(axisName);
            }
        }

        return 0;
    }

    // Prevents errors when a button is not assigned
    private bool GetButtonDown()
    {
        if (!(buttonName is null))
        {
            if (buttonName.Length > 0)
            {
                return Input.GetButtonDown(buttonName);
            }
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canHit = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canHit = false;
        spriteRenderer.color = originalColor;

        if (!hit)
        {
            MissCallback();
        }
        else
        {
            hit = false;
        }
    }
}
