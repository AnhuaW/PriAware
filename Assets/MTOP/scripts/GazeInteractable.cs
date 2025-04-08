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
    [SerializeField]public List<BoundingBox> boundingBoxes = new List<BoundingBox>();
    [SerializeField] private GameObject left_hand;
    [SerializeField] private GameObject right_hand;
    public Material oculusHandMat;
    public Material hightLightMat;
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
        StartCoroutine(ScaleOverTime(new Vector3(0.15f, 0.15f, 0.15f), 0.5f));
    }

    public void ScaleDown()
    {
        StartCoroutine(ScaleOverTime(new Vector3(0.1f, 0.1f, 0.1f), 0.5f));
    }

    public void ShowBoundingBoxes()
    {
        boundingBoxes.ForEach(b => b.lineRenderer.enabled = true);
    }

    public void HideBoundingBoxes()
    {
        boundingBoxes.ForEach(b => b.lineRenderer.enabled = false);
    }

    public void ShowHightLights()
    {
        SkinnedMeshRenderer smrL = left_hand.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer smrR = right_hand.GetComponent<SkinnedMeshRenderer>();
        smrL.materials = new Material[] { hightLightMat };
        smrR.materials = new Material[] { hightLightMat };
    }

    public void HideHightLights()
    {
        SkinnedMeshRenderer smrL = left_hand.GetComponent<SkinnedMeshRenderer>();
        SkinnedMeshRenderer smrR = right_hand.GetComponent<SkinnedMeshRenderer>();
        smrL.materials = new Material[] { oculusHandMat };
        smrR.materials = new Material[] { oculusHandMat };
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
