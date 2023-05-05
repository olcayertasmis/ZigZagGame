using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 _direction = Vector3.left;

    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        Vector3 hareket = _direction * speed * Time.deltaTime;

        transform.position += hareket;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_direction.x == 0)
            {
                _direction = Vector3.left;
            }

            else
            {
                _direction = Vector3.forward;
            }
        }   
    }



}//Class
