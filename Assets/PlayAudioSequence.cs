using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayAudioSequence : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    UnityEvent onPause = new UnityEvent();
    [SerializeField] AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        StartCoroutine(PlayWithDelay());
    }
    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (AudioClip clip in audioClips)
        {
            _audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
            if (clip.name == "question")
            {
                onPause.Invoke();
            }
        }
    }
}
