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
        public string goal;
        public char status;   //S- Success F- Fail N- Not Complete
        public int coolDown;
    }
    public List<GameTask> gameTasks;
    public const int SuccessScore=100;
    public const int FailScore = 150;
    public Text timec;
    public Text ScoreText; //宣告一個ScoreText的text
    public int Score = 0;
    public static int FinalSuccessCount, FinalFailCount = 0;
    private string min;
    private string sec;
    public float temp;
    // Use this for initialization
    void Start()
    {

        FinalSuccessCount = 0;
        FinalFailCount = 0;
        temp = 3660f;
        gameTasks = new List<GameTask>();
        Score = 0;
        GenerateTask("water");
        GenerateTask("food");
        GenerateTask("room");
        //GenerateTask("food");
        Application.targetFrameRate = 60;
    }
    System.Random rnd = new System.Random();
    public int GetNextRandomPlayer(int start, int end)
    {
        int index,count;
        count = 0;
        do
        {
            count++;
            index = rnd.Next(start, end);
            if (count > 4) break;
        }
        while (!checkRoleOK(index));
        if (count > 4)
        {

            return -1;
        }
        else
        {

            return index;
        }
    }
    public bool checkRoleOK(int index)
    {
        foreach (GameTask t in gameTasks)
        {
            if(t.index==index && t.status == 'N')
            {
                return false;
            }
        }
        return true;
    }
    public bool GenerateTask(string name)
    {
        int index=0;
        switch (name)
        {
            case "water":

                index = GetNextRandomPlayer(3, 6);
                if(index>0)
                    gameTasks.Add(new GameTask() { name= name, index = index ,status='N'});
                break;
            case "food":

                index = GetNextRandomPlayer(3, 6);
                if (index > 0)
                    gameTasks.Add(new GameTask() { name = name, index = index, status = 'N' });
                break;
            case "toilet":

                index = GetNextRandomPlayer(2, 2);
                if (index > 0)
                    gameTasks.Add(new GameTask() { name = name, index = index, status = 'N' });
                break;
            case "tv":
                index = GetNextRandomPlayer(3, 6);
                if (index > 0)
                    gameTasks.Add(new GameTask() { name = name, index = index, status = 'N' });
                break;
            case "room":
                index = GetNextRandomPlayer(7, 7);
                if (index > 0)
                    gameTasks.Add(new GameTask() { name = name, index = index, status = 'N' });
                break;
            default:
                break;
        }
        return index > 0;
    }
    // Update is called once per frame
    float countDown = 0;
    public static int finalScore;
    void Update()
    {
        countDown += Time.deltaTime;
        if(countDown > 5.0f)
        {
            GenerateTask("toilet");
            if (gameTasks.Count<4)
                GenerateRandomTask();
            countDown = 0f;
        }
        times();
        temp0();
        if (temp <= 0.0f)
        {
            finalScore = Score;
            goShowResult();
        }
        ScoreText.text = "Score: " + Score;
        CheckTaskStatus();
    }

    private void CheckTaskStatus()
    {
        foreach(GameTask task in gameTasks)
        {
            if (task.status == 'S')
            {
                AddScore();
                task.status = 'E';
            }
            else if (task.status == 'F')
            {
                ReduceScore();
                task.status = 'E';
            }
        }
    }

    public List<string> taskList = new List<string>() { "water","food", "toilet", "tv", "room" };
   
     private void GenerateRandomTask()
    {
       int index= rnd.Next(0, 4);
        string taskName = taskList[index];
        GenerateTask(taskName);
    }

    public void goStart()
    {
        SceneManager.LoadScene("start");
    }
    public void goShowResult()
    {
        SceneManager.LoadScene("ShowResult");
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

        Score += SuccessScore; //分數+10
        FinalSuccessCount += 1;
         // 更改ScoreText的內容
    }
    public void ReduceScore()

    {

        Score -= FailScore; //分數+10
        FinalFailCount += 1;
        // 更改ScoreText的內容
    }

}
