using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : MonoBehaviour
{
    [SerializeField]
    private KeyCode leftKeyCode;

    [SerializeField]
    private KeyCode downKeyCode;

    [SerializeField]
    private KeyCode upKeyCode;

    [SerializeField]
    private KeyCode rightKeyCode;

    private Dictionary<KeyCode, string> inputToArrowMapping;

    private string arrowTag;
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
        inputToArrowMapping = new Dictionary<KeyCode, string>();
        inputToArrowMapping.Add(leftKeyCode, "LeftArrow");
        inputToArrowMapping.Add(downKeyCode, "DownArrow");
        inputToArrowMapping.Add(upKeyCode, "UpArrow");
        inputToArrowMapping.Add(rightKeyCode, "RightArrow");

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("isAHit", 0);
        animator.SetInteger("isInputting", 0);
        // Check each input press: reward for the successful press and punish for each unsuccessful press
        foreach (KeyValuePair<KeyCode, string> entry in inputToArrowMapping)
        {
            // do something with entry.Value or entry.Key

            if (Input.GetKeyDown(entry.Key))
            {
                animator.SetInteger("isInputting", 1);

                if (arrowTag == entry.Value)
                {
                    //Debug.Log("HIT!");
                    ValidHitCallback();

                    animator.SetInteger("isAHit", 1); //Tells the animator is a hit and not a miss for the animation

                    // Replace this with better animation
                    spriteRenderer.color = new Color(255f, 255f, 0f, 255f);

                    arrowTag = null;
                    hit = true;
                }
                else
                {
                    //Debug.Log("MISS!");
                    MissCallback();

                }
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        arrowTag = other.gameObject.tag;

        if (!inputToArrowMapping.ContainsValue(arrowTag))
        {
            arrowTag = null;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        arrowTag = null;

        // Revert to original sprite color.
        spriteRenderer.color = originalColor;

        if (!hit)
        {
            MissCallback();
        }

        hit = false;
    }
}
