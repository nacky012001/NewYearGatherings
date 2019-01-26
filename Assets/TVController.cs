using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVController : MonoBehaviour
{

    public List<Sprite> sprites;
    public SpriteRenderer channel;
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
        if (currentIndex == 4)
        {
            currentIndex = 0;
        }
        channel.sprite = sprites[currentIndex];
        FindObjectOfType<UncleController>().Submit(currentIndex);
    }
}
