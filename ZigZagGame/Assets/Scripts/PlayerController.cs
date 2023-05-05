using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 _direction = Vector3.forward;

    [SerializeField] private float speed;

    private GroundSpawner _groundSpawner;

    private void Awake()
    {
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
    }

    private void FixedUpdate()
    {
        Vector3 hareket = _direction * speed * Time.deltaTime;

        transform.position += hareket;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_direction.x == 0) _direction = Vector3.left;

            else _direction = Vector3.forward;
        }   
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _groundSpawner.CreateGround();

            _groundSpawner.UnActiveGroundTask(collision.transform);
        }
    }


}//Class
