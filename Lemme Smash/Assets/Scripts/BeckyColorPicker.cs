using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeckyColorPicker : MonoBehaviour
{
    private float waitingTime;
    private float thinkingTime;

    private bool isThinking;
    private bool isPressed;
    private BeckyColor currColor;
    
    public enum BeckyColor
    {
        RED,
        BLUE,
        GREEN,
        YELLOW
    }

    // Start is called before the first frame update
    private void Awake()
    {
        waitingTime = 2f;
        thinkingTime = 1f;
        isThinking = false;
        isPressed = false;

        StartCoroutine(ChooseColor());
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void SetColorPressed(BeckyColor colorPressed/*, successCallback, failCallback (?)*/)
    {
        if (isThinking)
        {
            if (!isPressed)
            {
                if (colorPressed == currColor)
                {
                    isPressed = true;
                    // call successCallback here
                }
            }

            // else call failCallback (?)
        }
    }

    private IEnumerator ChooseColor()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitingTime);

            // choose color
            currColor = BeckyColor.RED; // set random

            Debug.Log($"Becky is thinking of {currColor}!");

            isThinking = true;

            // Wait for thinking time; stop prematurely if a player chooses the correct color.
            for (float timer = thinkingTime; timer >= 0; timer -= Time.deltaTime * Time.timeScale)
            {
                if (isPressed)
                {
                    Debug.Log($"Pressed {thinkingTime - timer} seconds after starting!");
                    break;
                }
                yield return null;
            }

            isThinking = false;
            isPressed = false;
        }
    }
}
