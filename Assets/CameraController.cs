using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private Rigidbody shipRb;

    private void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        shipRb = cam.Follow.GetComponentInParent<Rigidbody>();
    }

    private void Update()
    {
        
    }
}
