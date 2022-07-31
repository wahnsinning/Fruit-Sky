using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    //private float speed =20.0f;

    private float targetTime = 10.0f;

    //float distance = Vector3.Distance (GameObject.FindWithTag("Player").transform.position, GameObject.FindWithTag("Angel").transform.position);


    private void OnTriggerEnter(Collider other)
    {
        Player1_script playerInventory = other.GetComponent<Player1_script>();

        //hier kommentar
        
    }
    
    // Update is called once per frame
    void Update()
    {

        targetTime -= Time.deltaTime;

        //bewegungsablauf
        if (targetTime <= 0.0f)
        {
            //verschwinden
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, -0.02f);
        }
        
        if (targetTime >1)
        {
            //spieler folgen
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindWithTag("Player").transform.position, 0.02f);
            
        }
        
        
    }
    
}
