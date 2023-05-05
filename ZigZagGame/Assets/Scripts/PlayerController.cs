using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 _direction = Vector3.forward;

    [SerializeField] private float speed;

    private GroundSpawner _groundSpawner;

    public bool isDead;

    private void Awake()
    {
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 hareket = _direction * speed * Time.deltaTime;

        transform.position += hareket;
    }

    private void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0))
        {
            if(_direction.x == 0) _direction = Vector3.left;

            else _direction = Vector3.forward;
        }

        if(transform.position.y < -1f)
        {
            isDead = true;
            gameObject.SetActive(false);
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
