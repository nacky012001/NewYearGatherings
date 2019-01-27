using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartC : MonoBehaviour
{
    public static bool p1;
    public static bool p2;
    public static float retemp;
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
        retemp = main.temp;
    }
    public void gohelp()
    {
        SceneManager.LoadScene("help");
        
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
    public void singleplayer()
    {
        p1 = true;
        p2 = false;
    }
    public void multipleplayer()
    {
        p1 = true;
        p2 = true;
    }

}
