using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManagement : MonoBehaviour
{
    public List<GameObject> ARContents;
    public KeyCode inputKey = KeyCode.Space;
    // Start is called before the first frame update
    private void Awake()
    {
        foreach (GameObject ARContent in ARContents)
        {
            ARContent.SetActive(false);
        }
    }
    void Start()
    {
        //TODO
    }

    void ShowARContents()
    {
        foreach(GameObject ARContent in ARContents)
        {
            ARContent.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            ShowARContents();
        }
    }
}
