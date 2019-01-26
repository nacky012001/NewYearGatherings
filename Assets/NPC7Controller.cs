using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
using UnityEngine;
using UnityEngine.AI;

public class NPC7Controller : MonoBehaviour
{
    public bool isDoing;
    public bool isGoBacked;
    public int index;
    public float countDown;
    // Start is called before the first frame update
    void Start()
    {
        
        isDoing = false;
        isGoBacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);
        if (task != null&& !isDoing && isGoBacked)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("First"), "time", 3f, "easeType", iTween.EaseType.linear));
            isDoing = true;
        }

        if (isDoing)
        {
            countDown += Time.deltaTime;
            if (countDown > 5)
            {
                GoBackFail();
                countDown = 0;
            }
        }
    }

    public void GoBack()
    {
        if (isDoing) { 
        iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Second"), "time", 3f, "easeType",iTween.EaseType.linear, "onComplete", "OnGoBacked"));
        ListExtensions.GetMyTask(FindObjectOfType<main>().gameTasks, index).status = 'S';
        isDoing = false;
            isGoBacked = false;
        }
    }
    public void GoBackFail()
    {
        if (isDoing)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Second"), "time", 3f, "easeType", iTween.EaseType.linear, "onComplete", "OnGoBacked"));
            ListExtensions.GetMyTask(FindObjectOfType<main>().gameTasks, index).status = 'F';
            isDoing = false;
            isGoBacked = false;
        }
    }
    public void OnGoBacked() {

        isGoBacked = true;
        countDown = 0;
    }
}
