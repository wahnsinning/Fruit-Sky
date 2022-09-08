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

    public GameObject Pause_Screen;
    public GameObject Game_Over_Title;
    public GameObject Pause_Title;
    public GameObject Resume_Button;

    private void Awake()
    {
        instance = this;
    }

    string flag = "";
    public int fruits = 0;
    int height = 0;
    public static int globalhighscore = 0;

    public int highscore = 0;

    int boostscore;
    int lives=3;
    
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Fruit: " + fruits.ToString();
        heightText.text = "Height: " + height.ToString()+ " m";
        highscoreText.text = "Highscore: " + globalhighscore.ToString() + " m";
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

    public void lowerFlag()
    {
        flag = "";
        FLAG.text = flag;
    }

    public void setHighscore(int y_pos)
    {
        if (y_pos > highscore)
        {
            highscore = y_pos;
        }
        

        if (y_pos > globalhighscore)
        {
            globalhighscore = y_pos;
        }
        highscoreText.text = "Highscore: " + globalhighscore.ToString() + " m";
    }

    public void setBoostScore()
    {
        boostscore++;
        boostScoreText.text = "Cocktails mixed: " + boostscore.ToString();
    }

    public void TakeDamage()
    {
        lives --;
        
        
        //Game Over wenn keine Leben mehr
        if (lives ==0)
        {
            Time.timeScale = 0;
            Pause_Screen.gameObject.SetActive(true);
            Pause_Title.gameObject.SetActive(false);
            Game_Over_Title.gameObject.SetActive(true);
            Resume_Button.gameObject.SetActive(false);

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

    public int gethighscore()
    {
        return highscore;
    }

    public int getglobalhighscore()
    {
        return globalhighscore;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
