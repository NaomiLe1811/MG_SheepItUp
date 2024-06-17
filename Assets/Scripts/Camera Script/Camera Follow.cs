using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private float damping = 200f;
   // private float height = 100f;

    private Vector3 startPos;

    private bool can_Follow;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
        can_Follow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        if (can_Follow)
        {
            // Keep the y-coordinate constant
            float offsetY = 4f; // Adjust this value if needed

            // Adjust the z-coordinate to move the camera further away
            float offsetZ = -4f; // Adjust this value as needed to control the distance from the player

            Vector3 targetPosition = new Vector3(player.position.x, player.transform.position.y + offsetY, player.position.z + offsetZ);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);
        }
    }

    public bool CanFollow
    {

        get
        {
            return can_Follow;
        }

        set
        {
            can_Follow = value;
        }

    }

} // class
