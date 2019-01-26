using System;
using System.Collections;
using System.Collections.Generic;
using Assets;
using UnityEngine;

public class GrandMaController : MonoBehaviour
{
    public bool isDoing;
    public bool isGoBacked;
    public int index;
    public float countDown;
    public GameObject ballon;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        isGoBacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);
        if (task != null && !isDoing && isGoBacked)
        {
            ballon.SetActive(true);
        }
        if (isDoing)
        {
            countDown += Time.deltaTime;
            if (countDown > speed+3)
            {
                GoBack();
                countDown = 0;
            }
        }
    }
    public void GoBack()
    {
        if (isDoing)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Back"+index), "time", speed-2, "easeType", iTween.EaseType.linear, "onComplete", "OnGoBacked"));
            FindObjectOfType<main>().gameTasks.GetMyTask(index).status = 'S';
            isDoing = false;
            isGoBacked = false;
        }
    }
    public void GoBackFail()
    {
        if (countDown < speed-1)
        {
        if (isDoing)
            {
                iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Back"+index), "time", speed-2, "easeType", iTween.EaseType.linear, "onComplete", "OnGoBacked"));
                FindObjectOfType<main>().gameTasks.GetMyTask(index).status = 'F';
                isDoing = false;
                isGoBacked = false;
            }
        }
    }
    public void OnGoBacked()
    {

        isGoBacked = true;
        countDown = 0;
    }

    public void StartWalk()
    {
        var task = FindObjectOfType<main>().gameTasks.GetMyTask(index);
        if (task != null && !isDoing &&isGoBacked)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Go"+index), "time", speed, "easeType", iTween.EaseType.linear));
            isDoing = true;
            ballon.SetActive(false);
        }

    }
}
