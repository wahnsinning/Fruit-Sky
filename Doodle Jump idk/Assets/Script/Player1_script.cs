using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player1_script : MonoBehaviour
{
    [SerializeField] private GameObject Cloud_prefab;
    [SerializeField] private GameObject Melone_prefab;
    [SerializeField] private GameObject Pfirsich_prefab;
    [SerializeField] private GameObject Blaubeeren_prefab;
    // VARIABLES
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10f;
    [SerializeField]
    private Rigidbody RB;
    
    // -- time delay -- 
    private float _coolDownTimeJump = 1f;
    private float _nextJumpTime = 0f;

    private bool melonenlock = false;

    public float steps_height = 0;

    public int NumberOfMelons { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(x:1f, y:0f, z:0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Objects();
        scoreManager.instance.changeHeight((int)transform.position.y+3);

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

        //TELEPORT BACK TO START WHEN FALLING
        if (transform.position.y < -20)
        {
            transform.position = new Vector3(0f, 0f, 0f);
        }
    }

    void Objects()
    { 
        //Neue Wolke
        if (transform.position.y > steps_height)
        {
        Instantiate(Cloud_prefab, new Vector3(Random.Range(-15, 15), steps_height, 0), Quaternion.identity);
        steps_height = steps_height + 4;
        }

        //Früchte erzeugen
        if (steps_height % 10 == 0 && melonenlock == false )
        {
        int x = Random.Range(0, 3);

            if(x==0)
            {
                Instantiate(Melone_prefab, new Vector3(Random.Range(-15, 15), steps_height+2f, 0f), Quaternion.identity);
                melonenlock = true;
            }
            if (x == 1)
            {
                Instantiate(Pfirsich_prefab, new Vector3(Random.Range(-15, 15), steps_height + 2f, 0f), Quaternion.identity);
                melonenlock = true;
            }
            if (x == 2)
            {
                Instantiate(Blaubeeren_prefab, new Vector3(Random.Range(-15, 15), steps_height + 2f, 0f), Quaternion.identity);
                melonenlock = true;
            }

        }

        if (steps_height % 10 != 0)
        {
            melonenlock = false;
        }

    }

    public void MelonCollected()
    {
        NumberOfMelons++;
    }
}
