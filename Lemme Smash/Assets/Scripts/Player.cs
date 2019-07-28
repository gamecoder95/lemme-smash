using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int score;
    private int multiplier;
    private HeatMeter heatMeter;

    private const int BASE_SCORE_INCR = 10;
    private const int BASE_HEAT_INCR = 5;
    private const int BASE_HEAT_DECR = 20;

    enum Multiplier
    {
        NORMAL = 1,
        HOT = 2,
        ON_FIRE = 4
    }

    public int HeatValue
    {
        get
        {
            return heatMeter.Value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        heatMeter = GetComponentInChildren<HeatMeter>();
        score = 0;
        multiplier = (int) Multiplier.NORMAL;

        // Set the callback
        InputBlock[] inputBlocks = GetComponentsInChildren<InputBlock>();
        foreach (var inputBlock in inputBlocks)
        {
            inputBlock.ValidHitCallback = () => {
                heatMeter.Value += BASE_HEAT_INCR;
                DetermineMultiplier();
                AddScore(BASE_SCORE_INCR);

                Debug.Log($"Heat = {heatMeter.Value}, Score = {score}");
            };

            inputBlock.MissCallback = () => {
                heatMeter.Value -= BASE_HEAT_DECR;
                DetermineMultiplier();

                Debug.Log($"Heat = {heatMeter.Value}, Score = {score}");
            };
        }
    }

    // Update is called once per frame
    void Update()
    {
        DetermineMultiplier();
    }

    private void LateUpdate()
    {
        // Debug.Log($"Multiplier is now {multiplier}, which is {(Multiplier) multiplier}!");
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd * multiplier;
    }

    private void DetermineMultiplier()
    {
        switch (heatMeter.State)
        {
            case HeatMeter.HeatMeterState.HOT:
                multiplier = (int)Multiplier.HOT;
                break;

            case HeatMeter.HeatMeterState.ON_FIRE:
                multiplier = (int)Multiplier.ON_FIRE;
                break;

            default:
                multiplier = (int)Multiplier.NORMAL;
                break;
        }
    }
}
