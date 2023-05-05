using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offSet;
    [SerializeField] private Transform target;

    private PlayerController playerController;

    private void Awake()
    {
        playerController = target.GetComponent<PlayerController>();
    }

    private void Start()
    {
        offSet = transform.position - target.position;
    }

    private void LateUpdate()
    {
        if (playerController.isDead) return;
        
        transform.position = (target.position + offSet);
    }
}
