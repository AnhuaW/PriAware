using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayAudioSequence : MonoBehaviour
{
    public List<AudioClip> audioClips1 = new List<AudioClip>(); // lecture pt1 + question
    public List<AudioClip> audioClips2 = new List<AudioClip>(); // name
    public List<AudioClip> audioClips3 = new List<AudioClip>(); // comment + lecture pt2
    public List<AudioClip> audioClips4 = new List<AudioClip>(); // response
    public Animator studentAnimator;
    public UnityEvent onQuestion = new UnityEvent();
    public UnityEvent onPause = new UnityEvent();
    public UnityEvent onResponse = new UnityEvent();
    public UnityEvent onResume = new UnityEvent();
    private bool onStart = true;
    public AudioSource studentAudioSource;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] Animator _animator;

    [SerializeField]private AnimatorStateInfo _stateInfo;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _animator = gameObject.GetComponent<Animator>();
        if (studentAnimator != null)
        {
            _stateInfo = studentAnimator.GetCurrentAnimatorStateInfo(0);
        }
        _animator.SetBool("isTalking", true);
        StartCoroutine(PlayWithDelay(audioClips1,0f,onQuestion));
    }
    // Update is called once per frame
    void Update()
    {
        // TODO cleared update function
    }

    public void RaiseHand()
    {
        studentAnimator.SetTrigger("raiseHand");
        Debug.Log("current stateinfo is raiseHand: " + studentAnimator.GetCurrentAnimatorStateInfo(0).IsName("raiseHand"));
        //Debug.Log("raiseHand triggered");
        StartCoroutine(PlayWithDelay(audioClips2, 0.3f, onPause));
    }

    public void AnswerQuestion()
    {
        //Play response audio
        Debug.Log("answerning questions");
        StartCoroutine(PlayWithDelay(audioClips4, 0.1f, onResume));
    }
    

    public void CallName()
    {
        _animator.SetBool("isTalking", false);
        studentAnimator.SetBool("isStanding", true);
        //StartCoroutine(PlayWithDelay(audioClips2, 0.2f, onResponse));
    }

    public void ResumeTalking()
    {
        StartCoroutine(PlayWithDelay(audioClips3, 0f));
        studentAnimator.SetBool("isStanding", false);
        _animator.SetBool("isTalking", true);
    }

    IEnumerator PlayWithDelay (List<AudioClip>audioClips, float delay, UnityEvent currUnityEvent = null)
    {
        if (onStart)
        {
            yield return new WaitForSeconds(0.5f);
            onStart = false;
        }
        yield return new WaitForSeconds(delay);
        foreach (AudioClip clip in audioClips)
        {
            _audioSource.clip = clip;
            _audioSource.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length);
            yield return new WaitForSeconds(0.5f);
        }
        //yield return new WaitForSeconds(0.5f);
        if (currUnityEvent != null)
        {
            currUnityEvent.Invoke();
            Debug.Log(currUnityEvent.ToString() + "is invoked");
        }
    }
}
