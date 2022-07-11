using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player1_script : MonoBehaviour 
{
    [SerializeField] private GameObject Cloud_prefab;
    [SerializeField] private GameObject Cloud_prefab1;
    [SerializeField] private GameObject Cloud_prefab2;
    [SerializeField] private GameObject Cloud_prefab3;
    [SerializeField] private GameObject Cloud_prefab4;
    [SerializeField] private GameObject Cloud_prefab5;
    [SerializeField] private GameObject Cloud_prefab6;
    [SerializeField] private GameObject Cloud_prefab7;
    [SerializeField] private GameObject Cloud_prefab8;
    [SerializeField] private GameObject Cloud_prefab9;
    [SerializeField] private GameObject Cloud_prefab10;
    [SerializeField] private GameObject Cloud_prefab11;

    [SerializeField] private GameObject Melone_prefab;
    [SerializeField] private GameObject Pfirsich_prefab;
    [SerializeField] private GameObject Blaubeeren_prefab;
    [SerializeField] private GameObject Erdbeere_prefab;
    [SerializeField] private GameObject Mandarine_prefab;
    [SerializeField] private GameObject Kiwi_prefab;
    [SerializeField] private GameObject Brombeere_prefab;
    [SerializeField] private GameObject Apple_prefab;
    [SerializeField] private GameObject Banana_prefab;

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


    public float targetTime = 5.0f;
    private float timer = 0f;


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
        scoreManager.instance.ScoreUpdate();

       


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
        //BOOST EINSETZEN
        if (Input.GetKeyDown("space"))

        {
            if (scoreManager.instance.getFruit() > 9)
            {
                scoreManager.instance.writeFruit();
                 _jumpingSpeed += 0.2f;

            }
                
        }
    }

    void Objects()
    {



        //SCHWIERIGKEITSSTUFEN
        if (transform.position.y > steps_height)
        {
            xPos = Random.Range(-15, 15);

            //Stufe0
            if (steps_height < 50)
            {
                Instantiate(Cloud_prefab, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }
            //Stufe1
            if (steps_height > 49 && steps_height < 100)
            {
                Instantiate(Cloud_prefab1, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe2
            if (steps_height > 99 && steps_height < 150)
            {
                Instantiate(Cloud_prefab2, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe3
            if (steps_height > 149 && steps_height < 200)
            {
                Instantiate(Cloud_prefab3, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe4
            if (steps_height > 199 && steps_height < 250)
            {
                Instantiate(Cloud_prefab4, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe5
            if (steps_height > 249 && steps_height < 300)
            {
                Instantiate(Cloud_prefab5, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe6
            if (steps_height > 299 && steps_height < 350)
            {
                Instantiate(Cloud_prefab6, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }

            //Stufe7
            if (steps_height > 349 && steps_height < 400)
            {
                Instantiate(Cloud_prefab7, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }
            //Stufe8
            if (steps_height > 499 && steps_height < 550)
            {
                Instantiate(Cloud_prefab8, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }
            //Stufe9
            if (steps_height > 549 && steps_height < 600)
            {
                Instantiate(Cloud_prefab9, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }
            //Stufe10
            if (steps_height > 599 && steps_height < 650)
            {
                Instantiate(Cloud_prefab10, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }
            //Stufe11
            if (steps_height > 649)
            {
                Instantiate(Cloud_prefab11, new Vector3(xPos, steps_height + 16, 0), Quaternion.identity);
                steps_height = steps_height + 4;
            }



            //Fr�chte erzeugen
            if (steps_height % 10 == 0 && melonenlock == false)
            {
                int fruitNr = Random.Range(0, 9);


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
                if (fruitNr == 3)
                {
                    Instantiate(Brombeere_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 4)
                {
                    Instantiate(Mandarine_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 5)
                {
                    Instantiate(Kiwi_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 6)
                {
                    Instantiate(Erdbeere_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 7)
                {
                    Instantiate(Apple_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
                    melonenlock = true;
                }
                if (fruitNr == 8)
                {
                    Instantiate(Banana_prefab, new Vector3(xPos, steps_height + 14f, 0f), Quaternion.identity);
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
