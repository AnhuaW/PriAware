using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoverIcon : MonoBehaviour
{
    // Start is called before the first frame update
    public float offset = 0f;
    public Camera rigCamera;
    public GameObject target;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(rigCamera != null)
        {
            //Vector3 iconPos = target.transform.position;
            //iconPos.y += offset;
            //this.transform.position = iconPos;
            this.transform.LookAt(rigCamera.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
