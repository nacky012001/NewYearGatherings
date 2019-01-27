using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        main.temp = 3660f;
        Screen.SetResolution(1366, 768, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void goHomeP()
    {
        SceneManager.LoadScene("HomeP");
    }
    public void seond60()
    {
        main.temp = 3660f;
    }
    public void seond30()
    {
        main.temp = 1860f;
    }
    public void seond120()
    {
        main.temp = 7260f;
    }

}
