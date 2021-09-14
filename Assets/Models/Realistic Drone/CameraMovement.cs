using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Serialized Variables
    [SerializeField]
    private Transform targetToFollow;
    [SerializeField]
    private float smoothening = 0.125f;
    [SerializeField]
    private Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = targetToFollow.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothening);

        transform.position = smoothedPosition;

        transform.LookAt(targetToFollow);
    }


}
