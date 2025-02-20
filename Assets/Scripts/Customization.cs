using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Customization : MonoBehaviour
{
    public ConeGenerator sensingRangeObject;
    public CollisionDetection collisionDetectionObject;
    public bool audio = true;
    public bool visual = true;
    public bool text = true;
    public bool tts = false;
    public GameObject[] audioObjects;
    public BoundingBox[] visualObjects;
    public GameObject[] textObjects;
  
    // Start is called before the first frame update
    void Start()
    {
        collisionDetectionObject = GameObject.FindObjectOfType<CollisionDetection>();
        audio = collisionDetectionObject.audioOn;
        text = collisionDetectionObject.textLabelOn;
        visual = collisionDetectionObject.boundingBoxOn;
        audioObjects = GameObject.FindGameObjectsWithTag("earcons");
        visualObjects = FindObjectsOfType<BoundingBox>();
        textObjects = GameObject.FindGameObjectsWithTag("textLabel");
        
    }

    public void ToggleAudio()
    {
        audio = !audio;
        collisionDetectionObject.audioOn = audio;
       
        foreach (GameObject audioObject in audioObjects)
        {
            audioObject.SetActive(audio);
        }
    }

    public void ToggleVisual()
    {
        visual = !visual;
        collisionDetectionObject.boundingBoxOn = visual;
 
       /* foreach (BoundingBox visualObject in visualObjects)
        {
            visualObject.GetComponent<LineRenderer>().enabled = visual;
        }*/
    }

    public void ToggleText()
    {
        text = !text;
        collisionDetectionObject.textLabelOn = text;
      
        foreach (GameObject textObject in textObjects)
        {
            textObject.SetActive(text);
        }
    }

    public void ToggleTTS()
    {
        tts = !tts;
        collisionDetectionObject.ttsOn = tts;
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
