using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;
    
    void LateUpdate()
    {
        Vector2 playerposition = playerController.gameObject.transform.position;
        Vector2 cameraposition = playerposition;
        transform.position = cameraposition;
    }
}
