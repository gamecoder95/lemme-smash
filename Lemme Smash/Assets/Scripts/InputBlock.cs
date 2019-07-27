using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCode;

    private bool valid;
    private bool hit;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public delegate void InputPressedFunc();
    public InputPressedFunc ValidHitCallback
    {
        get; set;
    }

    public InputPressedFunc MissCallback
    {
        get; set;
    }

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
                //Debug.Log("HIT!");
                ValidHitCallback();
                spriteRenderer.color = new Color(255f, 255f, 0f, 255f);
                valid = false;
                hit = true;
            }
            else
            {
                //Debug.Log("MISS!");
                MissCallback();
            }
        }

        if (gameObject.name == "LeftBlock")
        {
            Debug.Log($"Valid = {valid}");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        valid = false;

        // Revert to original sprite color.
        spriteRenderer.color = originalColor;

        if (!hit)
        {
            MissCallback();
        }

        hit = false;
    }

    private void HandleCollision(GameObject other)
    {
        valid = (other.tag != "ComboBreaker");
    }
}
