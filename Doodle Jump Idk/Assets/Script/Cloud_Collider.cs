using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Collider : MonoBehaviour

{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //wolken solide wenn spieler darüber
        if (transform.position.y < GameObject.FindWithTag("Player").transform.position.y)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }

        //wolken durchlässig wenn spieler darunter
        if (transform.position.y > GameObject.FindWithTag("Player").transform.position.y)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }



    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        if (collision.relativeVelocity.magnitude > 2)
        {
            Player1_script.instance.ResetJumps();
        }
            
        
    }
}
