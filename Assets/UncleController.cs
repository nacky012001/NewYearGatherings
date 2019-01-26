using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using Assets.tasks;
using UnityEngine;

public class UncleController : MonoBehaviour
{

    public int index;
    public GameObject ballon;
    private TVShow tv;
    public bool isTaskComplete;
    public System.Random ran;

    void Start()
    {
        ran = new System.Random();
        tv = new TVShow();
        isTaskComplete = true;
    }
    public List<Color> colorList = new List<Color>() { Color.green, Color.yellow, Color.blue };
    // Update is called once per frame
    void Update()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);

     

        if (task != null && isTaskComplete)
        {
            ballon.gameObject.SetActive(true);

            switch (task.name)
            {
                case "tv":
                    int tvindex = getRanDomTVChannel();
                    tv.setIndex(tvindex);
                    ballon.GetComponentInChildren<SpriteRenderer>().color = colorList[tvindex];
                    isTaskComplete = false;
                    break;
            }
        }
        else if(task==null)
        {
            ballon.gameObject.SetActive(false);
        }
    }

    private int getRanDomTVChannel()
    {
        int tvIndex;
        do
        {
            tvIndex = ran.Next(0, 3);
        } while (tvIndex == FindObjectOfType<TVController>().currentIndex);
        return tvIndex;
    }

    public void Submit(int tvIndex)
    {
      

        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);

        if (task != null)
        {
            switch (task.name)
            {
                case "tv":
                    if (tv.IsComplete(tvIndex))
                    {
                        task.status = 'S';
                        isTaskComplete = true;
                    }

                    break;
            
            }
        }
    }
}
