using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text FLAG;// testing purposes: insert "scoreManager.instance.raiseFlag();" to be notified when something happens

    private void Awake()
    {
        instance = this;
    }

    string flag = "";
    int melons = 0;
    int height = 0; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Melons: " + melons.ToString();
        highscoreText.text = "Height: " + height.ToString()+ " m";
    }

    public void AddPoint()
    {
        melons += 1;
        scoreText.text = melons.ToString() + " Melons";
    }
    public void changeHeight(int y_pos)
    {
        height = y_pos;
        highscoreText.text = "Height: " + height.ToString() + " m";
    }

    public void raiseFlag()
    {
        flag = "FLAG";
        FLAG.text = flag;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
