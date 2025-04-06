using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBoxManager : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.grey;
    public Color startColor1 = Color.red;
    public Color endColor1 = Color.blue;
    [SerializeField] private BoundingBox[] boundingBoxes;
    // Start is called before the first frame update
    void Start()
    {
        boundingBoxes = GameObject.FindObjectsOfType<BoundingBox>();
        foreach (BoundingBox box in boundingBoxes)
        {
            if (box.gameObject.GetComponent<Animator>() != null && box.gameObject.GetComponent<spatial>()== null)
            {
                box.startColor = startColor1;
                box.endColor = endColor1;
            }
            else
            {
                box.startColor = startColor;
                box.endColor = endColor;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
