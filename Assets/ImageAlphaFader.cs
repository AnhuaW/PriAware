using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaFader : MonoBehaviour
{
    [SerializeField] private Image targetImage; 
    public float cycleDuration = 2f; // Duration for a full cycle (fade in and out)
    
    private void Start()
    {
        targetImage = GetComponent<Image>();
        if (targetImage == null)
        {
            Debug.LogError("ImageAlphaFader: No Image component assigned!");
            return;
        }
        StartCoroutine(FadeAlpha());
    }

    private IEnumerator FadeAlpha()
    {
        float halfDuration = cycleDuration / 2f;
        while (true)
        {
            yield return StartCoroutine(Fade(0f, 1f, halfDuration)); // Fade in
            yield return StartCoroutine(Fade(1f, 0f, halfDuration)); // Fade out
        }
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;
        Color color = targetImage.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            targetImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        targetImage.color = new Color(color.r, color.g, color.b, endAlpha);
    }
}
