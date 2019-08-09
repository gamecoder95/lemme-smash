using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Sequence sequence;
    public WinLose winLose;

    public GameObject EndMenu;
    public Text p1_score_text;
    public Text p2_score_text;

    private GameObject player1;
    private GameObject player2;

    void Start()
    {
        EndMenu.SetActive(false);

        sequence = GameObject.FindGameObjectWithTag("Spawner").GetComponent<Sequence>();
        winLose = GameObject.FindGameObjectWithTag("ResultManager").GetComponent<WinLose>();

        player1 = winLose.player1;
        player2 = winLose.player2;
    }

    void Update()
    {
        if(winLose.gameEnd)
        {
            sequence.StopCoroutine("SpawnArrows");//stop sequence of arrows here
            EndMenu.SetActive(true);
        }
    }

    public void ShowScore()
    {
        p1_score_text.text = "Score: " + player1.GetComponent<Player>().score.ToString();
        p2_score_text.text = "Score: " + player1.GetComponent<Player>().score.ToString();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");//reload current scene
    }
}
