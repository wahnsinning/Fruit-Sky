using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(Camera))]
public class Camera_Movement_script : MonoBehaviour
{
    //2 targets are needed because there are two players
    public List<Transform> targets;
    public Vector3 offset;
    
        
    private void Start()
    {
        offset = transform.position - targets[0].position; 
    }
 
    //camera moves up and down according to upper player
    
    private void LateUpdate()
    {
        
        if(targets[0] != null && targets[1] != null)
        {
            // ADD OFFSET - to our position in order to depict the player properly
            if (targets[0].position.y >= targets[1].position.y)
            {
                transform.position = offset + new Vector3(0f, targets[0].position.y, 0f);
            }
            
            if(targets[0].position.y <= targets[1].position.y)
            {
                transform.position = offset + new Vector3(0f, targets[1].position.y, 0f);
            }
        }
    }

}