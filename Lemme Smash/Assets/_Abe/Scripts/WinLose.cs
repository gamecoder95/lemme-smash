using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private Player player1_script;
    private Player player2_script;

    public Timer timer;

    public Text player1Text;
    public Text player2Text;

    public bool p1_win = false;
    public bool p1_lose = false;
    public bool p2_win = false;
    public bool p2_lose = false;
    public bool gameEnd = false;

    private void Start()
    {
        player1_script = player1.GetComponent<Player>();
        player2_script = player2.GetComponent<Player>();
    }

    void Update()
    {
        if (timer.timeRemaining <= 0)
        {
            DetermineResult();
            gameEnd = true;
        }

        if (p1_win)
        {
            player1Text.text = ("SMASH!");
        }
        if (p1_lose)
        {
            player1Text.text = ("PASS...");
        }
        if (p2_win)
        {
            player2Text.text = ("SMASH!");
        }
        if (p2_lose)
        {
            player2Text.text = ("PASS...");
        }
    }

    private void DetermineResult()
    {
        if(player1_script.score > player2_script.score)//if player 1 has a larger score than player 2, player 1 wins
        {
            p1_win = true;
            Debug.Log("Player1 wins!");
        }
        else
        {
            p1_lose = true;
        }

        if (player2_script.score > player1_script.score)//if player 2 has a larger score than player 1, player 2 wins
        {
            p2_win = true;
            Debug.Log("Player2 wins!");
        }
        else
        {
            p2_lose = true;
        }
    }
}
