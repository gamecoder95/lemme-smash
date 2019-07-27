using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBlock : MonoBehaviour
{

    [SerializeField]
    private KeyCode keyCode;

    private bool valid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (valid)
            {
                Debug.Log("HIT!");
            }
            else
            {
                Debug.Log("MISS!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        valid = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        valid = false;
    }
}
