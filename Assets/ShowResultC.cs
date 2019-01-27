using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResultC : MonoBehaviour
{
    public int a = 20;

    public Text finalscoreText;
    public Text successscoreText;
    public Text failscoreText;
    public GameObject win;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
        if (main.finalScore > a * ((main.temp - 60) / 60))
             { win.SetActive(true); }
        else
             { lose.SetActive(true);  }
        finalscoreText.text = main.finalScore.ToString();
        successscoreText.text = main.FinalSuccessCount.ToString() +" X "+ main.SuccessScore + " = " + (main.FinalSuccessCount* main.SuccessScore).ToString();
        failscoreText.text = main.FinalFailCount.ToString()+ " X -"+ main.FailScore + " = -" + (main.FinalFailCount * main.FailScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void goStart()
    {
        SceneManager.LoadScene("start");
        win.SetActive(false);
        lose.SetActive(false);
    }
}
