using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        Vector3 newVec = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, newVec, smoothSpeed * Time.deltaTime);
        transform.LookAt(target);
    }

    //private void FixedUpdate()
    //{
    //    Vector3 newVec = target.position + offset;
    //    transform.position = Vector3.Lerp(transform.position, newVec, smoothSpeed * Time.fixedDeltaTime);
    //    transform.LookAt(target);
    //}
}
