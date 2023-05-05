using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offSet;
    [SerializeField] private Transform target;

    private void Start()
    {
        offSet = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = (target.position + offSet);
    }
}
