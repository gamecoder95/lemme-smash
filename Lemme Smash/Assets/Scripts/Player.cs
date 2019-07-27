using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int score;
    private int multiplier;
    private HeatMeter heatMeter;

    enum Multiplier
    {
        NORMAL = 1,
        HOT = 2,
        ON_FIRE = 4
    }

    // Start is called before the first frame update
    void Start()
    {
        heatMeter = GetComponentInChildren<HeatMeter>();
        score = 0;
        multiplier = (int) Multiplier.NORMAL;
    }

    // Update is called once per frame
    void Update()
    {
        switch (heatMeter.State)
        {
            case HeatMeter.HeatMeterState.HOT:
                multiplier = (int) Multiplier.HOT;
                break;

            case HeatMeter.HeatMeterState.ON_FIRE:
                multiplier = (int) Multiplier.ON_FIRE;
                break;

            default:
                multiplier = (int) Multiplier.NORMAL;
                break;
        }
    }

    private void LateUpdate()
    {
        // Debug.Log($"Multiplier is now {multiplier}, which is {(Multiplier) multiplier}!");
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * multiplier;
    }
}
