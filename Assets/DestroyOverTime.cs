using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
        public float lifetime = 5f; // Time in seconds before the object is destroyed

        void Start()
        {
            Destroy(gameObject, lifetime);
        }

}
