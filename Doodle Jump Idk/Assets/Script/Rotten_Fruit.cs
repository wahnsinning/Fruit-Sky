using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotten_Fruit : MonoBehaviour
{
    float speed = 50.0f;

    void OnTriggerEnter(Collider other)
    {
        Player1_script playerInventory1 = other.GetComponent<Player1_script>();

        if (playerInventory1 != null)
        {


            gameObject.SetActive(false);

            scoreManager.instance.TakeDamage();
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up * speed * Time.deltaTime);
    }

}