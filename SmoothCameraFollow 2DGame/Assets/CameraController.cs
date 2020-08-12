using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 3f;

    private void LateUpdate()
    {
        Vector3 newVec = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newVec, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
