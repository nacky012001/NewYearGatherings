using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NPC7Controller : MonoBehaviour
{

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("First"), "time", 5f));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoBack()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("name", "test", "path", iTweenPath.GetPath("Second"), "time", 5f));
    }
}
