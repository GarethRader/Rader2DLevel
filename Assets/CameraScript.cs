using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraScript : MonoBehaviour
{

    [SerializeField] Transform player;
        
    void Update()
    {   
        HandleMovement();
    }
    private void HandleMovement(){
        Vector3 cameraFollowPosition = player.position;
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, this.transform.position);
        float cameraMoveSpeed = 1f;
        if(distance > 0){
            Vector3 newCameraPosition = this.transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
             
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if(distanceAfterMoving > distance){
                // overshot target
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }
 
    
}
