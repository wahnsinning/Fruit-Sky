using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GO_score : MonoBehaviour
{
    public static GO_score instance;

    public TMP_Text yourScoreText;
    public TMP_Text yourGlobalScoreText;
    public TMP_Text yourScoreTextP;
    public TMP_Text yourGlobalScoreTextP;

    private void Awake()
    {
        instance = this;
    }

    int yourScore = 0;
    int yourGlobalScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        yourScoreText.text = "Your Score: " + yourScore.ToString() +" m";
        yourGlobalScoreText.text = "Highscore: " + yourGlobalScore.ToString() +" m";

        yourScoreTextP.text = "Your Score: " + yourScore.ToString() +" m";
        yourGlobalScoreTextP.text = "Highscore: " + yourGlobalScore.ToString() +" m";
    }

    public void getYourScore()
    {
        yourScore = scoreManager.instance.gethighscore();
        yourScoreText.text = "Your Score: " + yourScore.ToString() + " m";
        yourScoreTextP.text = "Your Score: " + yourScore.ToString() +" m";

        yourGlobalScore = scoreManager.instance.getglobalhighscore();
        yourGlobalScoreText.text = "Highscore: " + yourGlobalScore.ToString() + " m";
        yourGlobalScoreTextP.text = "Highscore: " + yourGlobalScore.ToString() +" m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
