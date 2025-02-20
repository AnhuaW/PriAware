using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBoxManager : MonoBehaviour
{
    public Color startColor = Color.white;
    public Color endColor = Color.grey;
    [SerializeField] private BoundingBox[] boundingBoxes;
    // Start is called before the first frame update
    void Start()
    {
        boundingBoxes = GameObject.FindObjectsOfType<BoundingBox>();
        foreach (BoundingBox box in boundingBoxes)
        {
            box.startColor = startColor;
            box.endColor = endColor;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
