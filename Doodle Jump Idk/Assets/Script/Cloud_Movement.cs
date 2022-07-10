using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Movement : MonoBehaviour
{
    float speed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);

        if (transform.position.x >= 14)
            speed = -10;
        if (transform.position.x <= -14)
            speed = 10;
    }
}
