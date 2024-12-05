using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetectionAlt : MonoBehaviour
{
    void OnTriggerEnter(GameObject other)
    {
        if (other.gameObject.CompareTag("SensingDevice"))
        {
            
        }
    }

    void OnTriggerExit(GameObject other)
    {
        
    }
}
