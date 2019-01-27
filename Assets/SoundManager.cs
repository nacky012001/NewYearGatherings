using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public GameObject questionSound;
    public GameObject failSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(string key)
    {
        switch (key) {
            case "q":
                Instantiate(questionSound);
                break;
            case "f":
                Instantiate(failSound);
                break;

        };

    }
}
