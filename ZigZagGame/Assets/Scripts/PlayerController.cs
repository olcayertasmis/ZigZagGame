using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    private Vector3 _direction = Vector3.forward;
    [SerializeField] private float speed;

    [Header("Other Scripts")]
    private GroundSpawner _groundSpawner;
    [SerializeField] private UIManager uIManager;

    [Header("Player Control")]
    public bool isDead;
    public bool isStart = false;

    private void Awake()
    {
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
    }

    private void FixedUpdate()
    {
        if (isDead && !isStart) return;

        Vector3 hareket = _direction * speed * Time.deltaTime;

        transform.position += hareket;
    }

    private void Update()
    {
        if (isDead && !isStart) return;

        PlayerMovement();

        OnDead();
    }

    private void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_direction.x == 0) _direction = Vector3.left;

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

    private void OnDead()
    {
        if (transform.position.y < -1f)
        {
            isDead = true;
            gameObject.SetActive(false);
            uIManager.RestartPanel(true);
            uIManager.PlayPanel(false);
        }
    }


}//Class
