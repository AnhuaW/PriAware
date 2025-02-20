using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicRipple : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource attached to the target object
    public GameObject rippleObject; // The object representing the ripple effect (e.g., sphere or ring)
    public ParticleSystem rippleParticles; // Optional: Particle system for the ripple effect

    private float[] audioSpectrum; // Array to hold spectrum data
    public float minRippleSize = 0.5f; // Minimum size of the ripple
    public float maxRippleSize = 1.0f; // Maximum size of the ripple
    public float expansionSpeed = 1.5f; // Speed at which the ripple grows
    public float initialSize = 0.5f; // Initial size of the ripple

    void Start()
    {
        // Initialize spectrum array
        audioSpectrum = new float[512]; // You can adjust the size depending on the frequency resolution needed
        if (rippleObject != null)
        {
            rippleObject.transform.localScale = new Vector3(initialSize, initialSize, initialSize); // Start with small ripple
        }
    }

    void Update()
    {
        // Get the audio spectrum data
        audioSource.GetSpectrumData(audioSpectrum, 0, FFTWindow.BlackmanHarris);

        // Calculate the average amplitude from the spectrum data (simplified)
        float amplitude = 0f;
        for (int i = 0; i < audioSpectrum.Length; i++)
        {
            amplitude += audioSpectrum[i];
        }
        amplitude /= audioSpectrum.Length;

        // Update the ripple based on audio amplitude
        UpdateRippleEffect(amplitude);
    }

    void UpdateRippleEffect(float amplitude)
    {
        // Map amplitude to the range of 0.5 to 1 (minRippleSize to maxRippleSize)
        float rippleScale = Mathf.Lerp(minRippleSize, maxRippleSize, amplitude*10000);

        // Apply the new scale to the ripple object
        rippleObject.transform.localScale = new Vector3(rippleScale,  rippleScale, rippleScale);

        // Optionally, if using a particle system, adjust the start size of particles
        if (rippleParticles != null)
        {
            var mainModule = rippleParticles.main;
            mainModule.startSize = rippleScale * 0.1f; // Scale particle size based on ripple size
        }
    }
}
