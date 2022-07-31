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
        if (transform.position.y < GameObject.FindWithTag("Player").transform.position.y)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
        }

        if (transform.position.y > GameObject.FindWithTag("Player").transform.position.y)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
