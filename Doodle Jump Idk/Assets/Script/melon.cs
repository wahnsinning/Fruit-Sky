using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melon : MonoBehaviour
{
    float speed = 50.0f;

    private void OnTriggerEnter(Collider other)
    {
        Player1_script playerInventory = other.GetComponent<Player1_script>();

        if (playerInventory != null)
        {
            playerInventory.MelonCollected();
            
            gameObject.SetActive(false);
            
            scoreManager.instance.AddPoint();
        }
    }
    
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up * speed * Time.deltaTime);
    }
    
}
