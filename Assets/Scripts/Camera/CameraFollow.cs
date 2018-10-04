using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float Smoothing = 5f;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }
    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, Smoothing * Time.deltaTime );
    }
}
