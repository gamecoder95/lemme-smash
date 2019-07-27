using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBlocks : MonoBehaviour
{
    [SerializeField]
    private KeyCode left;

    [SerializeField]
    private KeyCode right;

    [SerializeField]
    private KeyCode up;

    [SerializeField]
    private KeyCode down;

    [SerializeField]
    private KeyCode becky;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(left))
        {
            //Debug.Log("LEFT!");
        }
        else if (Input.GetKeyDown(right))
        {
            //Debug.Log("RIGHT!");
        }
        else if (Input.GetKeyDown(up))
        {
            //Debug.Log("UP!");
        }
        else if (Input.GetKeyDown(down))
        {
            //Debug.Log("DOWN!");
        }
        else if (Input.GetKeyDown(becky))
        {
            //Debug.Log("BECKY!");
        }
    }

    private enum ButtonType
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        BECKY,
        COMBO_BREAKER
    }
}
