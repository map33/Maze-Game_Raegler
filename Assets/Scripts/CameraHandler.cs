using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [Header("The player")]
    public Transform player;

    [Header("Distance from the player")]
    public float yOffset;
    public float zOffset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.position + new Vector3(0, yOffset, -zOffset);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0, yOffset, -zOffset);
    }
}
