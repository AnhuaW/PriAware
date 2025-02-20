using System;
using System.Collections;
using System.Collections.Generic;
using Meta.WitAi.TTS.Utilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GazeInteractable : MonoBehaviour
{
    public UnityEvent OnGazeEnter;
    public UnityEvent OnAudioComplete;
    public UnityEvent OnGazeExit;
    // Start is called before the first frame update
    void Start()
    {
        //TODO
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EyeGaze"))
        {
            OnGazeEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EyeGaze"))
        {
            OnGazeExit.Invoke();
        }
    }

    public void ScaleUp()
    {
        StartCoroutine(ScaleOverTime(new Vector3(0.3f, 0.3f, 0.3f), 0.5f));
    }

    public void ScaleDown()
    {
        StartCoroutine(ScaleOverTime(new Vector3(0.2f, 0.2f, 0.2f), 0.5f));
    }
    
    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        transform.localScale = targetScale; // Ensure the final scale is exact
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
