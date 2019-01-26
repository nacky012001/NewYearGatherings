using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;
using System.Diagnostics;
using System; //#1
public class main : MonoBehaviour
{
    public class GameTask {
        public string name;
        public int index;
        public char status;   //S- Success F- Fail N- Not Complete

    }
    public List<GameTask> gameTasks;
    public Text timec;
    public Text ScoreText; //宣告一個ScoreText的text
    public int Score = 0;
    private string min;
    private string sec;
    public float temp;
    // Use this for initialization
    void Start()
    {
        temp = 3660f;
        gameTasks = new List<GameTask>();
    }
    // Update is called once per frame
    void Update()
    {
        times();
        temp0();

    }

    public void gostate1()
    {
        SceneManager.LoadScene("state1");
    }
    public void times()
    {
        min = Mathf.Floor(temp / 60 / 60f).ToString("00");
        sec = Mathf.Floor(temp / 60 % 60f).ToString("00");
        timec.text = String.Format("{0:D}:{1:D}", min, sec);
    }

    public void temp0()
    {

        if (temp > 0)
        {
            temp = temp - 1f;
        }
    }
    public void AddScore()

    {

        Score += 10; //分數+10

        ScoreText.text = "Score: " + Score; // 更改ScoreText的內容
    }
    public void ReduceScore()

    {

        Score -= 10; //分數+10

        ScoreText.text = "Score: " + Score; // 更改ScoreText的內容
    }

}
