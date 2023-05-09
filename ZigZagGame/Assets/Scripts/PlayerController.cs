using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    private Vector3 _direction = Vector3.forward;
    [SerializeField] private float speed;
    private int speedControl = 0;

    [Header("Other Scripts")]
    private GroundSpawner _groundSpawner;
    [SerializeField] private UIManager uIManager;
    private Score score;

    [Header("Player Control")]
    public bool isDead;
    public bool isStart = false;

    private void Awake()
    {
        _groundSpawner = GetComponentInChildren<GroundSpawner>();
        score = GetComponent<Score>();
    }

    private void FixedUpdate()
    {
        if (!isDead && !isStart) return;

        Vector3 hareket = _direction * (speed * Time.deltaTime);

        transform.position += hareket;
    }

    private void Update()
    {
        if (isDead) OnDead();
        if (!isDead && !isStart) return;
        if (transform.position.y < -1f) OnDead();

        PlayerMovement();
        CheckScore30Mod();
    }

    private void PlayerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_direction.x == 0) _direction = Vector3.left;

            else _direction = Vector3.forward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            score.IncreaseScore(5f);

            other.gameObject.SetActive(false);
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
        isDead = true;
        gameObject.SetActive(false);
        uIManager.RestartPanel(true);
        uIManager.PlayPanel(false);
    }

    private void CheckScore30Mod()
    {
        if ((int)score.score / 30 > speedControl && score.score != 0)
        {
            speed += .25f;
            speedControl++;
        }
    }
} //Class