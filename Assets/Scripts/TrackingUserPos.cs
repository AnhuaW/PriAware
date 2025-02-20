using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingUserPos : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
    }
}
