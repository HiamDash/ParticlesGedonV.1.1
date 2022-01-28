using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    Vector3 cameraInitialPosition;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;
   
    public CinemachineOrbitalTransposer orbital;
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    
    void Update()
    {
        ShakeIt();
    }

    public void ShakeIt()
    {
        cameraInitialPosition = orbital.transform.position;
        InvokeRepeating("StartCameraShake", 0f, 0.005f);
        Invoke(" StopCameraShaking", shakeTime);
    }
    void StartCameraShake()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosistion = orbital.transform.position;
        cameraIntermadiatePosistion.x += cameraShakingOffsetX;
        cameraIntermadiatePosistion.y += cameraShakingOffsetY;
        orbital.transform.position = cameraInitialPosition;

    }
    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShake");
        orbital.transform.position = cameraInitialPosition;
    }
}
