using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int timeRemaining = 60;
    public Text time_text;

    void Start()
    {
        StartCoroutine("DecreaseTime");
    }

    void Update()
    {
        if (timeRemaining <= 0)
        {
            StopCoroutine("DecreaseTime");
        }
        time_text.text = ("TIME: " + timeRemaining);
    }

    IEnumerator DecreaseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }
    }
}
