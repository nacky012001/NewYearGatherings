using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResultC : MonoBehaviour
{
    public Text finalscoreText;
    public Text successscoreText;
    public Text failscoreText;
    // Start is called before the first frame update
    void Start()
    {
        finalscoreText.text = main.finalScore.ToString();
        successscoreText.text = main.FinalSuccessCount.ToString() +" X "+ main.SuccessScore + " = " + (main.FinalSuccessCount* main.SuccessScore).ToString();
        failscoreText.text = main.FinalFailCount.ToString()+ " X "+ main.FailScore + " = " + (main.FinalFailCount * main.FailScore).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goStart()
    {
        SceneManager.LoadScene("start");
    }
}
