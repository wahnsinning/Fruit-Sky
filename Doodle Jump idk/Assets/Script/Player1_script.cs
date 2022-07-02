using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_script : MonoBehaviour
{
    [SerializeField] private GameObject Cloud_prefab;
    // VARIABLES
    [SerializeField]
    private float _speed = 5f;
    private float _jumpingSpeed = 10f;
    [SerializeField]
    private Rigidbody RB;
    
    // -- time delay -- 
    private float _coolDownTimeJump = 1f;
    private float _nextJumpTime = 0f;

    public float progress_y=10;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(x:1f, y:0f, z:0f);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

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
            if (transform.position.y < -10)
            {
                transform.position = new Vector3(0f, 0f, 0f);
            }
            //Neue Wolke
            if (transform.position.y > progress_y)
            {
            Instantiate(Cloud_prefab, new Vector3(Random.Range(-5, 10), progress_y, 0), Quaternion.identity);
            progress_y = progress_y + 4;
            }
    }
}
