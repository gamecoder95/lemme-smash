using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeckyColorPicker : MonoBehaviour
{

    private BeckyColor currColor;
    private float thinkingTimeWindow;
    private float thinkingTimeStamp;
    private bool pressed;

    public enum BeckyColor
    {
        NONE,
        RED,
        BLUE,
        YELLOW,
        GREEN
    }

    private float ThinkingTime
    {
        get
        {
            return (Time.time - thinkingTimeStamp);
        }
    }

    private bool IsThinking
    {
        get
        {
            return (!pressed && ThinkingTime < thinkingTimeWindow);
        }
    }


    // Start is called before the first frame update
    private void Awake()
    {
        thinkingTimeStamp = 0f;
        pressed = false;
        thinkingTimeWindow = 1f;//2f;

        StartCoroutine(ChooseColor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetPressed(BeckyColor colorPressed)
    {
        if (IsThinking)
        {
            pressed = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    private IEnumerator ChooseColor()
    {
        // Initial time delay
        yield return new WaitForSeconds(1);

        while (true)
        {
            currColor = BeckyColor.RED; // Choose one out of random
            Debug.Log($"Becky is thining of {currColor}!");

            thinkingTimeStamp = Time.time;
            while (IsThinking)
            {
                // do nothing and just wait
            }

            pressed = false;
            currColor = BeckyColor.NONE;


            // loop time
            yield return new WaitForSeconds(1);
        }
    }
}
