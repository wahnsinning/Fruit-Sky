using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GO_score : MonoBehaviour
{
    public static GO_score instance;

    public TMP_Text yourScoreText;

    private void Awake()
    {
        instance = this;
    }

    int yourScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        yourScoreText.text = "Your Score: " + yourScore.ToString() +" m";
    }

    public void getYourScore()
    {
        yourScore = scoreManager.highscore;
        yourScoreText.text = "Your Score: " + yourScore.ToString() + " m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
