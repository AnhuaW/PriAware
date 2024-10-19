using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceController : MonoBehaviour
{
    // Start is called before the first frame update

    public bool enableVisual2D = false;
    public bool enableVisualSpatial = false;
    public bool enableTextDescription = false;
    public bool enableAudio2D = false;
    public bool enableAudio3D= false;
    public bool enableAudioDescription= false;
    public GameObject visualSpatial;
    public GameObject visual2D;
    public GameObject textDescription;
    public GameObject audio2D;
    public GameObject audio3D;
    public GameObject audioDescription;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enableVisual2D && visual2D)
            {
                ToggleGuidance(visual2D);
            }

            if(enableVisualSpatial && visualSpatial)
            {
                ToggleGuidance(visualSpatial);
            }

            if(enableTextDescription && textDescription)
            {
                ToggleGuidance(textDescription);
            }

            if(enableAudio2D && audio2D)
            {
                ToggleGuidance(audio2D);
            }

            if(enableAudio3D && audio3D)
            {
                ToggleGuidance(audio3D);
            }

            if(enableAudioDescription && audioDescription)
            {
                ToggleGuidance(audio2D);
            }
        } 
    }

    void ToggleGuidance(GameObject guidanceObject)
    {
        bool isActive = guidanceObject.activeSelf;
        guidanceObject.SetActive(!isActive);
    }
}
