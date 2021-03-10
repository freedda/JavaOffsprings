
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform followTarget;

    public Vector3 offset;

    private float currentZoom = 9f;
    private float minZoom = 3f;
    private float maxZoom = 15f;
    private float zoomSpeed = 4f;
    private float speed = 100f;
    private float currentSpeed = 0f;

    void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel")* zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentSpeed -= Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = followTarget.position - offset * currentZoom;
        //Look at target 
        transform.LookAt(followTarget.position + Vector3.up * 2f);
        
        //Rotate the camera around our target with A and D
        transform.RotateAround(followTarget.position, Vector3.up, currentSpeed);
    }
}
