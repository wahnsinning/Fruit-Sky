using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1_script : MonoBehaviour 
{
    [SerializeField] private GameObject Cloud_prefab;
    [SerializeField] private GameObject Melone_prefab;
    [SerializeField] private GameObject Pfirsich_prefab;
    [SerializeField] private GameObject Blaubeeren_prefab;

    //Sreen Layers 
    public GameObject Game_Over_Screen;
    public GameObject Pause_Screen;

    // VARIABLES
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10f;
    [SerializeField]private Rigidbody RB;
    
    // -- time delay -- 
    private float _coolDownTimeJump = 1f;
    private float _nextJumpTime = 0f;

    private int xPos = 0;
    private bool melonenlock = false;

    public float steps_height = 0;

    public int NumberOfMelons { get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        transform.position = new Vector3(x:1f, y:0f, z:0f);
        Game_Over_Screen.gameObject.SetActive(false);
        Pause_Screen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Objects();
        scoreManager.instance.changeHeight((int)transform.position.y+3);
        scoreManager.instance.setHighscore((int)transform.position.y +3);
        GO_score.instance.getYourScore();


    }
    void PlayerMovement()
    {
        // MOVEMENT
        if (Input.GetKeyDown("right"))
        {
            RB.velocity += new Vector3(_speed, 0f, 0f);
            //transform.Translate(Vector3.right * Time.deltaTime * _speed *1);
        }
        if (Input.GetKeyDown("left"))
        {
            RB.velocity += new Vector3(-_speed, 0f, 0f);
            //transform.Translate(Vector3.right * Time.deltaTime * _speed *1);
        }

        // JUMPING
        if (Input.GetKeyDown("up") && _nextJumpTime < Time.time)
        {
            RB.velocity += new Vector3(0f, _jumpingSpeed, 0f);
            _nextJumpTime = Time.time + _coolDownTimeJump;
        }

        //Falling too deep
        if (transform.position.y < -13)
        {
            Time.timeScale = 0;
            Game_Over_Screen.gameObject.SetActive(true);
        }

        //PAUSE
        if (Input.GetKeyDown("p"))
        {
            PauseGame();
            Pause_Screen.gameObject.SetActive(true);
        }

        //RESUME
        if(Input.GetKeyDown("r"))
        {
            ResumeGame();
            Pause_Screen.gameObject.SetActive(false);
        }
    }

    void Objects()
    { 
        //Neue Wolke
        if (transform.position.y > steps_height)
        {
            xPos = Random.Range(-15, 15);

            Instantiate(Cloud_prefab, new Vector3(xPos, steps_height+ 16, 0), Quaternion.identity);
            steps_height = steps_height + 4;

            //Fr�chte erzeugen
            if (steps_height % 10 == 0 && melonenlock == false)
            {
                int fruitNr = Random.Range(0, 3);


                if (fruitNr == 0)
                {
                    Instantiate(Melone_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 1)
                {
                    Instantiate(Pfirsich_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 2)
                {
                    Instantiate(Blaubeeren_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }

            }
        }

        

        if (steps_height % 10 != 0)
        {
            melonenlock = false;
        }

    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void MelonCollected()
    {
        NumberOfMelons++;
    }
    
}
