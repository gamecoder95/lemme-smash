using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCode;

    private bool valid;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (valid)
            {
                Debug.Log("HIT!");

                spriteRenderer.color = new Color(255f, 255f, 0f, 255f);
            }
            else
            {
                Debug.Log("MISS!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SetValidTrue(other.gameObject.tag);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        SetValidTrue(other.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        valid = false;

        // Revert to original sprite color.
        spriteRenderer.color = originalColor;
    }

    private void SetValidTrue(string otherTag)
    {
        valid = (otherTag != "ComboBreaker");
    }
}
