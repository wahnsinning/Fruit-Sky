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
    public TMP_Text yourScoreText;
    public TMP_Text boostScoreText;
    

    public TMP_Text FLAG;// testing purposes: insert "scoreManager.instance.raiseFlag();" to be notified when something happens

    public GameObject Game_Over_Screen;

    private void Awake()
    {
        instance = this;
    }

    string flag = "";
    public int fruits = 0;
    int height = 0;
    public static int highscore = 0;

    int boostscore;
    int lives=3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Fruit: " + fruits.ToString();
        heightText.text = "Height: " + height.ToString()+ " m";
        highscoreText.text = "Highscore: " + highscore.ToString() + " m";
    }

    public void AddPoint()
    {
        fruits += 1;
        scoreText.text = fruits.ToString() + " Fruit";
    }

    public void ScoreUpdate()
    {
        scoreText.text = fruits.ToString() + " Fruit";
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

    public void setBoostScore()
    {
        boostscore++;
        boostScoreText.text = "Cocktails bought: " + boostscore.ToString();
    }

    public void TakeDamage()
    {
        lives --;
        
        
        //Game Over wenn keine Leben mehr
        if (lives ==0)
        {
            Time.timeScale = 0;
            Game_Over_Screen.gameObject.SetActive(true);
        }
        //Herzen entfernen
        if (lives==2)
            GameObject.FindWithTag("herz2").SetActive(false);

        if (lives == 1)
            GameObject.FindWithTag("herz1").SetActive(false);

        if (lives == 0)
            GameObject.FindWithTag("herz").SetActive(false);

    }

    public int getFruit()
    {
        return fruits;
    }
    public void writeFruit()
    {
        fruits = fruits-3;
    }

    public int getHeight()
    {
        return height;
    }

    public int getlives()
    {
        return lives;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
