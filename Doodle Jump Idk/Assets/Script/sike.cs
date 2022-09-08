using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sike : MonoBehaviour
{

    public GameObject sikespeech;
    
    private float targetTime = 5.0f;

    private bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        sikespeech.gameObject.SetActive(false);
    }

    void Update()
    {
        if (destroyed==false)
        {
            if (sikespeech.gameObject.active)
            {
                targetTime -= Time.deltaTime;

                if (targetTime <= 0.0f)
                {
                    Destroy(sikespeech.gameObject);
                    destroyed=true;
                }
            }
        }
        
    }
}
