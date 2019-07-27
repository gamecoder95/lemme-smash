using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBlock : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCode;

    private bool valid;
    private SpriteRenderer spriteRenderer;

    private const string COMBO_BREAKER_TAG = "ComboBreaker";

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
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
                spriteRenderer.color = new Color(255f, 0f, 175f, 255f);
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
    }

    private void SetValidTrue(string otherTag)
    {
        if (otherTag != COMBO_BREAKER_TAG)
        {
            valid = true;
        }
    }
}
