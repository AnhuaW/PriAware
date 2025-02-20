using System;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.PoseDetection;
using UnityEngine;

public class SensorTypeManager : MonoBehaviour
{
    public CollisionMeshHandler cameraVisual;
    public GameObject cameraIndicator;

    public GameObject micVisual;
    public GameObject micIndicator;
    // Start is called before the first frame update
    [SerializeField] private AudioSource controllerAudio;
    [SerializeField] private bool isCameraActive = true;

    private void Start()
    {
        controllerAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            controllerAudio.Play();
            if(isCameraActive)
            { 
                isCameraActive = false;
               ToggleCamera(false);
               ToggleMic(true);
              Debug.Log("truning camera off, turning mic on");
            }
            else
            {
                isCameraActive = false;
                ToggleCamera(true);
                ToggleMic(false);
                isCameraActive = true;
                Debug.Log("turning mic off, turning camera on");
            }
        }
    }

    void ToggleCamera(bool turnOn)
    {
        cameraIndicator.SetActive(turnOn);
        cameraVisual.ToggleSpatialVisual(turnOn);
    }

    void ToggleMic(bool turnOn)
    {
        micVisual.SetActive(turnOn);
        micIndicator.SetActive(turnOn);
    }
    
}
