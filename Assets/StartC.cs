using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(800, 600, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goHomeP()
    {
        SceneManager.LoadScene("HomeP");
    }
}
