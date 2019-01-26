using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVController : MonoBehaviour
{
    public Text channel;
    public List<String> channelList = new List<string>() { "Sport", "Drama", "Film" };
    public int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextChannel()
    {
        currentIndex++;
        if (currentIndex == 3)
        {
            currentIndex = 0;
        }
        channel.text = channelList[currentIndex];
    }
}
