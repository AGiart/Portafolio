using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float damping = 0.5F;

    Vector3 _velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 position = target.position + offset;
        position.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, position, ref _velocity, damping);
    }
}
