using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public TMP_Text highscoreText;
    public TMP_Text scoreText;
    public TMP_Text heightText;
    public TMP_Text FLAG;// testing purposes: insert "scoreManager.instance.raiseFlag();" to be notified when something happens

    private void Awake()
    {
        instance = this;
    }

    string flag = "";
    int melons = 0;
    int height = 0;
    public int highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Fruits: " + melons.ToString();
        heightText.text = "Height: " + height.ToString()+ " m";
        highscoreText.text = "Highscore: " + highscore.ToString() + " m";
    }

    public void AddPoint()
    {
        melons += 1;
        scoreText.text = melons.ToString() + " Fruits";
    }
    public void changeHeight(int y_pos)
    {
        height = y_pos;
        heightText.text = "Height: " + height.ToString() + " m";
    }

    public void raiseFlag()
    {
        flag = "FLAG";
        FLAG.text = flag;
    }

    public void setHighscore(int y_pos)
    {
        if (y_pos > highscore)
        {
            highscore = y_pos;
        }
        highscoreText.text = "Highscore: " + highscore.ToString() + " m";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
